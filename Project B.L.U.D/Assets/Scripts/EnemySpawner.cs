using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public float spawnDistance = 5.0f;
    public float distanceFromTrigger = 2.0f;
    GameObject clone;
    Transform spawnLocation;
    public Transform[] triggerLocations;
    double timer;
    public static bool spawned = false;
    public AudioClip clip;
    public bool playedSFX = true;
    public AudioClip clip2;

    void Spawn()
    {
        clone = Instantiate(enemy, new Vector3(spawnLocation.position.x - ((int)(Random.value*2)*2-1)*spawnDistance, spawnLocation.position.y, spawnLocation.position.z), Quaternion.identity) as GameObject;
    }

    void TimeSpawn(){
        timer += Time.deltaTime;
        if (timer >= 10 && spawned == false)
        {
            Spawn();
            spawned = true;
        }
        if (timer >= 20 && spawned == true)
        {
            Despawn();
            spawned = false;
            timer = 0;
        }
    }

    void TriggerSpawn() {
        timer += Time.deltaTime;
        foreach (Transform element in triggerLocations)
        {
            if (Vector3.Distance(element.position, spawnLocation.transform.position) < distanceFromTrigger && spawned == false){
                Spawn();
                spawned = true;
            }
            if (timer > 10)
                Despawn();
        }
    }

    void Despawn()
    {
        Destroy(clone);
    }

	// Use this for initialization
	void Start () {
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        spawnLocation = GameObject.FindGameObjectWithTag("Player").transform;
        //TriggerSpawn();
        if (spawned && playedSFX)
        {
            AudioManager.instance.PlaySFXClip(clip, .6f);
            playedSFX = false;
            AudioManager.instance.StopMusic();
            AudioManager.instance.PlayMusic(clip2);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawned == false)
            {
                Spawn();
                spawned = true;
            }
        }

    }
}

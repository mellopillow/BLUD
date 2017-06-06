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
    public static bool playedSFX = true;
    int randomHit = 1;
    

    void Spawn()
    {
        clone = Instantiate(enemy, new Vector3(spawnLocation.position.x - ((int)(Random.value*2)*2-1)*spawnDistance, triggerLocations[0].position.y, spawnLocation.position.z), Quaternion.identity) as GameObject;
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
        spawned = false;
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
            AudioManager.instance.PlayMusic(AudioManager.instance.music[2], .9f);
        }
        if (!spawned && !playedSFX)
        {
            AudioManager.instance.StopSFX();
            AudioManager.instance.StopMusic();
            playedSFX = true;
            AudioManager.instance.randomMusic(AudioManager.instance.music);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawned == false)
            {
                // 30% chance of spawning
                int random_value = Random.Range(0, 3);
                print(random_value);
                if (random_value == randomHit)
                {
                    print("random hit");
                    print(random_value);
                    Spawn();
                    spawned = true;
                }
            }
        }

    }
}

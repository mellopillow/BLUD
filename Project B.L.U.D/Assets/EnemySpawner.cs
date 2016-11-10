using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public float distanceBetween;
    GameObject clone;
    Transform spawnLocation;
    public Transform[] triggerLocations;
    double timer;
    bool spawned;


    void Spawn()
    {
        clone = Instantiate(enemy, new Vector3(spawnLocation.position.x - (Random.value*2-1)*distanceBetween, spawnLocation.position.y, spawnLocation.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
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
        foreach (Transform element in triggerLocations)
        {
            if (Vector3.Distance(element.position, spawnLocation.transform.position) < 5 && spawned == false){
                Spawn();
                spawned = true;
                TimeSpawn();
            } 
        }
    }

    void Despawn()
    {
        Destroy(clone);
    }

	// Use this for initialization
	void Start () {
        spawnLocation = GameObject.FindGameObjectWithTag("Player").transform;
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        TriggerSpawn();
        
	}
}

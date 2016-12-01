using UnityEngine;
using System.Collections;

public class killMyself : MonoBehaviour {
    double timer;
	// Use this for initialization
	void Start () {
        timer = 0;
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update () {
       
        
	}

    ~killMyself()
    {
        EnemySpawner.spawned = false;
    }
}



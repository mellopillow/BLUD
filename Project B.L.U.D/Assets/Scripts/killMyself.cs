using UnityEngine;
using System.Collections;

public class killMyself : MonoBehaviour {
	// Use this for initialization
	void Start () {
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



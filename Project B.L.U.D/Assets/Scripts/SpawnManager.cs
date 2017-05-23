using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject Player = GameObject.FindGameObjectWithTag("Player");
		Transform startpoint = null;
		if (ItemScript.spawnlocation == 0) {
			startpoint = GameObject.Find ("startpoint0").transform;
		}
		if (ItemScript.spawnlocation == 1) {
			Debug.Log ("1");
			startpoint = GameObject.Find ("startpoint1").transform;
		}
		else if (ItemScript.spawnlocation == 2) {
			Debug.Log ("2");
			startpoint = GameObject.Find ("startpoint2").transform;
		}
		Player.transform.position = startpoint.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

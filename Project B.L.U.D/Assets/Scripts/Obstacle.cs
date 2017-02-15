using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public int blocking_counter;
	public int counter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (counter != blocking_counter)
			this.gameObject.SetActive (true);
		else if (counter == blocking_counter)
			this.gameObject.SetActive (false);
	}
}

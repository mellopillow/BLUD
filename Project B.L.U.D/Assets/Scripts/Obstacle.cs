using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public int blocking_counter;
	public int counter = 0;
	public GameObject back_gate;
	public GameObject front_gate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (counter != blocking_counter) {
			this.gameObject.SetActive (true);
			back_gate.SetActive (false);
			front_gate.SetActive (false);
		}
		else if (counter == blocking_counter) {
			this.gameObject.SetActive (false);
			back_gate.SetActive (true);
			front_gate.SetActive (true);
		}
	}
}

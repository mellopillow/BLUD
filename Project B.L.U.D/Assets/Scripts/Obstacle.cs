using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public bool blocking = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (blocking == true)
			this.gameObject.SetActive (true);
		else if (blocking == false)
			this.gameObject.SetActive (false);
	}
}

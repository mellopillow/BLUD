using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCrittersSaved : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (ItemScript.first_critter == true && ItemScript.second_critter == true && ItemScript.third_critter == true) {
			this.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

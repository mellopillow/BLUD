using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCritter : MonoBehaviour {

	public float proximity;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			if (CheckCloseTo ("Player", proximity)) {
				if (ItemScript.third_critter == false) {
					if (ItemScript.third_critter_met == false) {
						ItemScript.third_critter_met = true;
						//meeting dialogue
					} else if (ItemScript.third_critter_met == true) {
						if (ItemScript.key2 == false) {
							//dialogue
						} else if (ItemScript.key2 == true) {
							ItemScript.third_critter = true;
							//saved dialogue
						}
					}
				}		
			}
		}
	}

	bool CheckCloseTo(string tag, float minimumDistance)
	{
		GameObject goWithTag = GameObject.FindGameObjectWithTag(tag);
		if (Vector3.Distance (transform.position, goWithTag.transform.position) <= minimumDistance)
			return true;
		else
			return false;
	}
}

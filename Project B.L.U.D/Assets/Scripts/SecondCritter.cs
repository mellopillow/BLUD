using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCritter : MonoBehaviour {

	public float proximity;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("e")) {
			if (CheckCloseTo ("Player", proximity)) {
				if (ItemScript.second_critter == false) {
					this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
					if (ItemScript.second_critter_met == false) {
						ItemScript.second_critter_met = true;
						Debug.Log ("met");
						//meeting dialogue
					} else if (ItemScript.second_critter_met == true) {
						if (ItemScript.slingshot == false) {
							//dialogue
						} else if (ItemScript.slingshot == true) {
							ItemScript.second_critter = true;
							Debug.Log ("saved");
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

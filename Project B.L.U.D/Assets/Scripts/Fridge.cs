using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour {

	public GameObject fridge2;
	public GameObject critter1;
	public GameObject door1;
	public GameObject door2;
	public int proximity;
	static bool finished = false;

	void Start () {
		if (finished == true) {
			this.gameObject.SetActive (false);
			door1.SetActive (false);
			fridge2.SetActive(true);
			door2.SetActive (true);
		}
	}

	void Update () {
		if (Input.GetKeyDown ("space")){
			if (CheckCloseTo ("Player", proximity)) {
				this.gameObject.SetActive (false);
				door1.SetActive (false);
				fridge2.SetActive(true);
				critter1.SetActive(true);
				door2.SetActive (true);
				ItemScript.chainsaw = true;
				finished = true;
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

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vines : MonoBehaviour {

	public float proximity;

	void Update () {
		if (Input.GetKeyDown ("space")){
			if (CheckCloseTo ("Player", proximity)) {
				if (ItemScript.chainsaw == true) {
					this.gameObject.SetActive (false);
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
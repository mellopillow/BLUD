using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2 : MonoBehaviour {

	public float proximity;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("e")){
			if (CheckCloseTo ("Player", proximity)) {
				if (ItemScript.slingshot == true) {
					ItemScript.key2 = true;
					Debug.Log ("KEY2");
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
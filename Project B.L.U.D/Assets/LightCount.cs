using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightCount : MonoBehaviour {

    Text LightText;
	// Use this for initialization
	void Start () {
        LightText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        LightText.text = "x " + ItemScript.battery_count;
	}
}

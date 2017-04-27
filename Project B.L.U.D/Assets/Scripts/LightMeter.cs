using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMeter : MonoBehaviour {
    public Material Mat;
    private const float coef = 0.2f;
    public float max_light = .5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Mat.SetFloat(Shader.PropertyToID("_Radius"), max_light -= coef * Time.deltaTime);
	}
}

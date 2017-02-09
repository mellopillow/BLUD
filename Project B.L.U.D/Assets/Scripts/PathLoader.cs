﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PathLoader : MonoBehaviour {

	public int level;
    public bool loadLevel;
	public float proximity;
	public Sprite Glow;
	public Sprite NoGlow;
    public Text text;
    string objectText = "Dis is lamp";

	void Start(){
		
	}


	void Update(){
        if (CheckCloseTo("Player", proximity)) {

            this.gameObject.GetComponent<SpriteRenderer>().sprite = Glow;
            
            text.material.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Mathf.Abs((this.transform.position.x - GameObject.FindWithTag("Player").transform.position.x * text.color.a / proximity)));
            // fades text in and out based on distance between player and object
            if (Input.GetMouseButton(0))
            {
                if(loadLevel)
                    SceneManager.LoadScene(level);
                text.text = objectText;
            }
        }

        else {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = NoGlow;
            text.text = "";
                }
        
        

    }

	bool CheckCloseTo(string tag, float minimumDistance){
		GameObject[] goWithTag = GameObject.FindGameObjectsWithTag (tag);
		for (int i = 0; i < goWithTag.Length; ++i) {
			if (Vector3.Distance (transform.position, goWithTag [i].transform.position) <= minimumDistance)
				return true;
		}
		return false;
	}

    void textFade()
    {
       
        
    }
}

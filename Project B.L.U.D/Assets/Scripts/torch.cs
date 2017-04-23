using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour {

	public Sprite lit;
	public Sprite unlit;
	public float proximity;
	public GameObject gate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){

			
	}


	void OnMouseDown()
	{
		if (CheckCloseTo ("Player", proximity)) {
			if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == lit) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = unlit;
				gate.GetComponent<Obstacle> ().counter -= 1;
			} 

			else {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = lit;
				gate.GetComponent<Obstacle> ().counter += 1;
			}
		}
	}


	bool CheckCloseTo(string tag, float minimumDistance){
		GameObject goWithTag = GameObject.FindGameObjectWithTag (tag);
		for (int i = 0; i < goWithTag.Length; ++i) {
			if (Vector3.Distance (transform.position, goWithTag [i].transform.position) <= minimumDistance)
				return true;
		}
		return false;
	}
}

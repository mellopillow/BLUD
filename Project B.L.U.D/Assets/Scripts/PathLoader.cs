using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathLoader : MonoBehaviour {

	public int level;
	public float proximity;
	public Sprite Glow;
	public Sprite NoGlow;

	void Start(){
		
	}


	void Update(){
		if (CheckCloseTo ("Player", proximity)) {

			this.gameObject.GetComponent<SpriteRenderer> ().sprite = Glow;

			if(Input.GetMouseButton(0))
			{
				SceneManager.LoadScene (level);
			}
		}

		else
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = NoGlow;
		
	}

	bool CheckCloseTo(string tag, float minimumDistance){
		GameObject[] goWithTag = GameObject.FindGameObjectsWithTag (tag);
		for (int i = 0; i < goWithTag.Length; ++i) {
			if (Vector3.Distance (transform.position, goWithTag [i].transform.position) <= minimumDistance)
				return true;
		}
		return false;
	}
}

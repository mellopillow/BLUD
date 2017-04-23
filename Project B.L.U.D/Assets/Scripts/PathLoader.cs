using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PathLoader : MonoBehaviour {

	public int level;
	public int spawnset;
    public bool loadLevel;
	public float proximity;
	public Sprite Glow;
	public Sprite NoGlow;
    public Text text;
    string objectText = "Dis is lamp";

	void Start(){
		
	}

	void Update(){
		if (CheckCloseTo ("Player", proximity)) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = Glow;
			if(Input.GetMouseButton(0))
			{
				GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ().spawnlocation = spawnset;
				SceneManager.LoadScene (level);
				Debug.Log ("hi");
			}
		}

		else {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = NoGlow;
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

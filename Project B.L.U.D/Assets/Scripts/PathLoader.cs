using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PathLoader : MonoBehaviour
{

    public int level;
	public int SpawnPoint;
    public bool loadLevel;
    public float proximity;
    public Sprite Glow;
    public Sprite NoGlow;
    public Text text;
    string objectText = "Dis is lamp";
    //bool clicked;

    void Update(){
       
		if (Input.GetKeyDown ("space")){
			if (CheckCloseTo("Player", proximity))
			{
				//clicked = true;
				if (loadLevel == true) {
					GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ().spawnlocation = SpawnPoint;
					SceneManager.LoadScene (level);
				}
			}
		}

		if (CheckCloseTo("Player", proximity))
		{
			text.material.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Mathf.Abs((this.transform.position.x - GameObject.FindWithTag("Player").transform.position.x * text.color.a / proximity)));
			// fades text in and out based on distance between player and object
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Glow;
			text.text = objectText;
		}

		else {
			//clicked = false;
			this.gameObject.GetComponent<SpriteRenderer>().sprite = NoGlow;
			text.text = "";
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

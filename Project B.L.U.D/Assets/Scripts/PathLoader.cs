using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PathLoader : MonoBehaviour
{

    public int LevelToLoad;
	public int SpawnPoint;
    public bool LoadLevel;
    public float ActivationProximity;
    public Sprite BaseImage;
    public Sprite ActivatedImage;
    Text text;
    LoadText load;
    public string[] ot;
    //bool clicked;
    public bool isBattery = false;

    void Start()
    {
        text = GameObject.FindWithTag("text").GetComponent<Text>();
        load = GameObject.FindWithTag("text").GetComponent<LoadText>();
    }

    void Update(){
       
		if (Input.GetKeyDown ("space") && !load.isLoading()){
			if (CheckCloseTo("Player", ActivationProximity))
			{
                load.LoadArray(ot);
                gameObject.GetComponent<SpriteRenderer>().sprite = ActivatedImage;
                //clicked = true;
                if (LoadLevel == true) {
					GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ().spawnlocation = SpawnPoint;
					SceneManager.LoadScene (LevelToLoad);
				}
                if (isBattery)
                {
                    ItemScript.items.incBattery();
                    isBattery = false; // only get battery once
                }
			}
		}

		if (CheckCloseTo("Player", ActivationProximity))
		{
			text.material.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a /*- Mathf.Abs((this.transform.position.x - GameObject.FindWithTag("Player").transform.position.x * text.color.a / ActivationProximity))*/);
            // fades text in and out based on distance between player and object
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ActivatedImage;
		}

		else {
			//clicked = false;
			this.gameObject.GetComponent<SpriteRenderer>().sprite = BaseImage;
            //load.load("");
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

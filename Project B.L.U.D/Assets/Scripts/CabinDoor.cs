using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CabinDoor : MonoBehaviour {

	public int level;
	public int SpawnPoint;
	public float proximity;

	void Update(){

		if (Input.GetKeyDown ("e")){
			if (CheckCloseTo("Player", proximity))
			{
				if (ItemScript.key == true) {
					GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ().spawnlocation = SpawnPoint;
					SceneManager.LoadScene (level);
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

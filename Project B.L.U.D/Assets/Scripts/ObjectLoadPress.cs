using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ObjectLoadPress : MonoBehaviour {

	public int Level;

	void Update(){
		if(Input.GetMouseButton(0))
		{
			SceneManager.LoadScene (Level);
		}
	}
}

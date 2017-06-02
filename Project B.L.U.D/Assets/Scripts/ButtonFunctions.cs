using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

    public GameObject GameManager;
    // Use this for initialization
    public void Continue()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        GameManager.GetComponent<GameManager>().Unpause();
    }

}

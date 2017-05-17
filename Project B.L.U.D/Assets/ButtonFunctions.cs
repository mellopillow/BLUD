using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

    // Use this for initialization
    public void Continue()
    {
        SceneManager.LoadScene(9);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

}

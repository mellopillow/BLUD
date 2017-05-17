using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class killPlayer : MonoBehaviour
{
    public int LevelToLoad;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(LevelToLoad);
        }
        
    }
}

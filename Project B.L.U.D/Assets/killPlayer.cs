using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class killPlayer : MonoBehaviour
{
    public Text gameOverText;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }

    }
}

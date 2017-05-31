using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameObject PauseMenu;
    public float levelStartDelay = 2f; // time delay for when starting and transitioning into levels or scene
    private Text levelText;
    private GameObject levelImage;
    private bool doingSetup;
    float alpha;

    void InitGame()
    {
        doingSetup = true;
        levelImage = GameObject.Find("Image");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        PauseMenu.SetActive(false);
        levelImage.SetActive(true);

    }

    private void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }
	// Use this for initialization
	void Start () {
        PauseMenu.SetActive(false);
        //Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
        if (Input.GetKeyDown(KeyCode.P))
            Unpause();
	}

    void Pause()
    {
        Time.timeScale = 0;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().freeze();
        GameObject.FindWithTag("Enemy").GetComponent<EnemyMovement>().freeze();
        PauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().unfreeze();
        GameObject.FindWithTag("Enemy").GetComponent<EnemyMovement>().unfreeze();
        PauseMenu.SetActive(false);
    }

    public float GetAlpha()
    {
        return alpha;
    }

    public void SetAlpha(float value)
    {
        alpha = value;
    }

}

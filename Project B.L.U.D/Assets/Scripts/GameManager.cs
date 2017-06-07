using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    

    public GameObject player;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject LightBar;
    GameObject SceneText;
    GameObject GameText;
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
        GameText.SetActive(true);
        SceneText.SetActive(true);
        PauseButton.SetActive(true);
        LightBar.SetActive(true);
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
        GameText = GameObject.FindWithTag("text");
        SceneText = GameObject.FindWithTag("SceneText");
        //Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
        if (Input.GetKeyDown(KeyCode.P))
            Unpause();
	}

    public void Pause()
    {
        Time.timeScale = 0;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().freeze();
        if (GameObject.FindWithTag("Enemy") != null)
            GameObject.FindWithTag("Enemy").GetComponent<EnemyMovement>().freeze();
        PauseMenu.SetActive(true);
        GameText.SetActive(false);
        SceneText.SetActive(false);
        PauseButton.SetActive(false);
        LightBar.SetActive(false);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().unfreeze();
        if (GameObject.FindWithTag("Enemy") != null)
            GameObject.FindWithTag("Enemy").GetComponent<EnemyMovement>().unfreeze();
        PauseMenu.SetActive(false);
        GameText.SetActive(true);
        SceneText.SetActive(true);
        PauseButton.SetActive(true);
        LightBar.SetActive(true);
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

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public float levelStartDelay = 2f; // time delay for when starting and transitioning into levels or scenes


    private Text levelText;
    private GameObject levelImage;
    private bool doingSetup;

    void InitGame()
    {
        doingSetup = true;
        levelImage = GameObject.Find("Image");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();

        levelImage.SetActive(true);

    }

    private void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }
	// Use this for initialization
	void Start () {
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.P))
            Time.timeScale = 1;
	}

    void Pause()
    {
        Time.timeScale = 0;
    }
}

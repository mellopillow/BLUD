﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PathLoader : MonoBehaviour
{

    public int level;
    public bool loadLevel;
    public float proximity;
    public Sprite Glow;
    public Sprite NoGlow;
    public Text text;
    string objectText = "Dis is lamp";
    bool clicked;

    void Update()
    {
        if (clicked && CheckCloseTo("Player", proximity))
        {
            text.material.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Mathf.Abs((this.transform.position.x - GameObject.FindWithTag("Player").transform.position.x * text.color.a / proximity)));
            // fades text in and out based on distance between player and object
            gameObject.GetComponent<SpriteRenderer>().sprite = Glow;
            text.text = objectText;
        }

        else {
            clicked = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = NoGlow;
            text.text = "";
        }
    }


    void OnMouseDown()
    {
        if (CheckCloseTo("Player", proximity))
        {
            clicked = true;
            if (loadLevel == true)
                SceneManager.LoadScene(level);
        }
    }


    bool CheckCloseTo(string tag, float minimumDistance)
    {
        GameObject[] goWithTag = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < goWithTag.Length; ++i)
        {
            if (Vector3.Distance(transform.position, goWithTag[i].transform.position) <= minimumDistance)
                return true;
        }
        return false;
    }
}

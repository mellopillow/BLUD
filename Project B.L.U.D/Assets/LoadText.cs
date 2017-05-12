using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour {

    bool loading;
    bool done;
    float timer = 0;
    float btimer = 0;
    int current = 0;
    public float loadingTime;
    string t="";
    string[] ot;
    int CurElement = 0;
    public float TimeBetween = 2f;
    bool SpacePressed;

    public void LoadArray(string[] text)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().freeze();
        SpacePressed = true;
        CurElement = 0;
        ot = text;
        if(ot.Length>0)
            load(ot[CurElement]);
    }
    public void load(string text)
    {
        clear();
        loading = true;
        t = text;
        current = 0;
    }

    public void clear()
    {
        t = "";
        loading = false;
    }

    void Start()
    {
        GetComponent<Text>().text = "";
    }

    void Update()
    {
        if (SpacePressed)
        {
            if (loading & current <= t.Length & CurElement < ot.Length)
            {
                timer += Time.deltaTime;
                if (timer > (loadingTime / t.Length))
                {
                    GetComponent<Text>().text = t.Substring(0, current);
                    current++;
                    timer = 0f;
                }
            }
            else {
                loading = false;
                SpacePressed = false;
                if (++CurElement < ot.Length)
                    load(ot[CurElement]);
            }
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                SpacePressed = true;
                if (CurElement >= ot.Length)
                {
                    GetComponent<Text>().text = "";
                    GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().unfreeze();
                }
            }

        }
    }

    public bool isLoading()
    {
        return CurElement>0 && CurElement<ot.Length+1;
    }
}

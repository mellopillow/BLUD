using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour {

    bool loading;
    float timer = 0;
    int current = 0;
    public float loadingTime;
    string t="";

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
        GetComponent<Text>().text = "";
        loading = false;
    }

    void Start()
    {
        GetComponent<Text>().text = "";
    }

    void Update()
    {
        if (loading & current<=t.Length)
        {
            timer += Time.deltaTime;
            if (timer > (loadingTime/t.Length))
            {
                GetComponent<Text>().text = t.Substring(0, current);
                current++;
                timer = 0f;
            }
        }
        else
            loading = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour {

    bool loading;
    float timer = 0;
    int current = 0;
    public float loadingTime;
    public Text GameText;
    string t="";

    public void load(string text)
    {
        t = text;
        loading = true;
    }

    void Start()
    {
        GameText.text = "";
    }

    void Update()
    {
        if (loading & current<=t.Length)
        {
            timer += Time.deltaTime;
            if (timer > (loadingTime/t.Length))
            {
                GameText.text = t.Substring(0, current);
                current++;
                timer = 0f;
            }
        }
        else
            loading = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour {

    bool started;
    bool first = true;
    bool loading;
    float timer = 0;
    int CurLetter = 0;
    public float loadingTime;
    string CurrentWord ="";
    string[] Sequence;
    int CurSentence = -1;
    bool SpacePressed;

    public void LoadArray(string[] text)
    {
        started = true;
        print("loading");
        first = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().freeze();
        print("Freeze");
        SpacePressed = true;
        CurSentence = 0;
        Sequence = text;
        if(Sequence.Length>0)
            load(Sequence[CurSentence]);
    }
    public void load(string text)
    {
        CurrentWord = "";
        loading = true;
        CurrentWord = text;
        CurLetter = 0;
    }

    void Start()
    {
        GetComponent<Text>().text = "";
    }

    void Update()
    {
        if (SpacePressed)
        {
            if (Input.GetKeyDown("e") && !first)
            {
                print("hello");
                CurLetter = CurrentWord.Length;
            }
            if (loading & CurLetter <= CurrentWord.Length & CurSentence < Sequence.Length)
            {
                timer += Time.deltaTime;
                if (timer > (loadingTime / CurrentWord.Length))
                {
                    GetComponent<Text>().text = CurrentWord.Substring(0, CurLetter);
                    CurLetter++;
                    timer = 0f;
                }
            }
            else {
                loading = false;
                SpacePressed = false;
                if (++CurSentence < Sequence.Length)
                    load(Sequence[CurSentence]);
            }
            first = false;
        }
        else {
            if (Input.GetKeyDown("e") && started)
            {
                SpacePressed = true;
                if (CurSentence >= Sequence.Length)
                {
                    GetComponent<Text>().text = "";
                    GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().unfreeze();
                    print("Unfreeze"); 
                }
            }
        }
    }

    public bool isLoading()
    {
        return CurSentence>=0 && CurSentence<Sequence.Length+1;
    }
}

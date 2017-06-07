using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightIndicator : MonoBehaviour {

    float ratio = 0f;
    public Image lightBar = null;
    //public Text lightText = null;
    //public Text healthTextOptional = null;
    bool hit;

    void Start()
    {
        //lightText.color = Color.white;
    }
    void Update()
    {
        updateLightBar();
    }

    void updateLightBar()
    {
        ratio = (ItemScript.current_light-ItemScript.min_light) / (.5f-ItemScript.min_light);
        lightBar.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
        //outline.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
        //lightText.text = "" + hitPoint;
        //healthTextOptional.text = "" + hitPoint;
    }
}

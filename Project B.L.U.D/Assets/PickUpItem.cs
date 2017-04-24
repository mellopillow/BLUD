using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{

    public Image icon;
    public Text ItemText;
    public Image IconHolder;
    public string PickUpText;
    public float FadeOutTime;
    float timer;
    bool PickedUp;

    // Use this for initialization
    void Start()
    {
        IconHolder = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (PickedUp)
            timer += Time.deltaTime;
        if (timer > 3)
        {
            ItemText.text = "";
            PickedUp = false;
            timer = 0f;
        }
    }

    void OnMouseDown()
    {
        PickedUp = true;
        PickUp();
    }

    void PickUp()
    {
        Destroy(gameObject);
        IconHolder = icon;
        ItemText.text = PickUpText;
    }
}

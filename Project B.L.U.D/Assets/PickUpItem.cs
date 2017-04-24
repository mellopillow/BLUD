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

    // Use this for initialization
    void Start()
    {
        IconHolder = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        PickUp();
    }

    void PickUp()
    {
        Destroy(gameObject);
        IconHolder = icon;
        ItemText.text = PickUpText;
    }
}

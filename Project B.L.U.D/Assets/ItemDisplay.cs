using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour {

    public Sprite Key1Image;
    public Sprite Key2Image;
    public Sprite ChainSawImage;
    public Sprite SlingShotImage;
    public Sprite Critter1Image;
    public Sprite Critter2Image;
    public Sprite Critter3Image;
    public Image Key1Holder;
    public Image Key2Holder;
    public Image ChainSawHolder;
    public Image SlingShotHolder;
    public Image Critter1Holder;
    public Image Critter2Holder;
    public Image Critter3Holder;

    public void UpdateItems(string item)
    {
        switch(item)
        {
            case "key1":
                Key1Holder.sprite = Key1Image;
                break;
            case "key2":
                Key2Holder.sprite = Key2Image;
                break;
            case "chainsaw":
                ChainSawHolder.sprite = ChainSawImage;
                break;
            case "slingshot":
                SlingShotHolder.sprite = SlingShotImage;
                break;
            case "first_critter":
                Critter1Holder.sprite = Critter1Image;
                break;
            case "second_critter":
                Critter2Holder.sprite = Critter2Image;
                break;
            case "third_critter":
                Critter3Holder.sprite = Critter3Image;
                break;
        }
    }

    void Update()
    {
        if (ItemScript.key)
            UpdateItems("key1");
        if (ItemScript.key2)
            UpdateItems("key2");
        if (ItemScript.chainsaw)
            UpdateItems("chainsaw");
        if (ItemScript.slingshot)
            UpdateItems("slingshot");
        if (ItemScript.first_critter)
            UpdateItems("first_critter");
        if(ItemScript.second_critter)
            UpdateItems("second_critter");
        if (ItemScript.third_critter)
            UpdateItems("third_critter");
    }


}

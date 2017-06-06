﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Slingshot : MonoBehaviour
{

	public int LevelToLoad;
	public int SpawnPoint;
	public bool LoadLevel;
	public float ActivationProximity;
	public Sprite BaseImage;
	public Sprite ActivatedImage;
	Text ExamineText;
	Text text;
	LoadText load;
	public string[] ot;
	//bool clicked;
	public bool isBattery = false;
	float original_alpha;
	bool JustExited;
	bool JustEntered;

	void Start()
	{
		original_alpha = 128;
		text = GameObject.FindWithTag("text").GetComponent<Text>();
		load = GameObject.FindWithTag("text").GetComponent<LoadText>();
		ExamineText = GameObject.FindWithTag("inspect").GetComponent<Text>();
	}

	void Update(){

		if (Input.GetKeyDown ("space") && !load.isLoading()){
			if (CheckCloseTo("Player", ActivationProximity))
			{
				load.LoadArray(ot);
				gameObject.GetComponent<SpriteRenderer>().sprite = ActivatedImage;
				//clicked = true;
				if (ItemScript.second_critter_met == true && ItemScript.slingshot == false) {
					ItemScript.slingshot = true;
					Debug.Log ("obtained slingshot");
					//slingshot dialogue
				}
				else {
					//default dialogue
				}
				if (LoadLevel == true) {
					ItemScript.spawnlocation = SpawnPoint;
					SceneManager.LoadScene (LevelToLoad);
				}
				if (isBattery)
				{
					ItemScript.items.incBattery();
					isBattery = false; // only get battery once
				}
			}
		}

		if (CheckCloseTo("Player", ActivationProximity))
		{
			JustExited = false;
			text.material.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a /*- Mathf.Abs((this.transform.position.x - GameObject.FindWithTag("Player").transform.position.x * text.color.a / ActivationProximity))*/);
			// fades text in and out based on distance between player and object
			gameObject.GetComponent<SpriteRenderer>().sprite = ActivatedImage;
			if (!load.isLoading())
			{
				ExamineText.text = "Examine";
				print(text.color.a - Mathf.Abs((transform.position.x -
					GameObject.FindWithTag("Player").transform.position.x * text.color.a / ActivationProximity)));
				ExamineText.material.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Mathf.Abs((transform.position.x -
					GameObject.FindWithTag("Player").transform.position.x * text.color.a / ActivationProximity)));
				RectTransform CanvasRect = GameObject.FindWithTag("canvas").GetComponent<RectTransform>();
				Vector2 ViewportPosition = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().WorldToViewportPoint(transform.position);
				Vector2 WorldObject_ScreenPosition = new Vector2(
					((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f))+ CanvasRect.sizeDelta.x / 20,
					((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f))+ViewportPosition.y*CanvasRect.sizeDelta.y/2);

				//now you can set the position of the ui element
				ExamineText.GetComponent<RectTransform>().anchoredPosition = new Vector2(WorldObject_ScreenPosition.x, WorldObject_ScreenPosition.y);
			}
		}

		else {
			ExamineText.material.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a);
			//clicked = false;
			if (!JustExited)
			{
				ExamineText.text = "";
				JustExited = true;
			}
			gameObject.GetComponent<SpriteRenderer>().sprite = BaseImage;
			//load.load("");
		}
	}


	bool CheckCloseTo(string tag, float minimumDistance)
	{
		GameObject goWithTag = GameObject.FindGameObjectWithTag(tag);
		if (Vector3.Distance (transform.position, goWithTag.transform.position) <= minimumDistance)
			return true;
		else
			return false;
	}
}

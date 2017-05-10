﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

	public static bool key = false;
	public static bool chainsaw = false;
	public static bool slingshot = false;
	public static bool first_critter = false;
	public static bool second_critter = false;
    // battery variables
	public static bool has_battery = false;
	public static int battery_count = 0;
    public static float max_light = 0.5f;
    public static float current_light = 0.5f;
    public static float decrease_rate = .01f;
    public static float min_light = 0.05f;
    private static bool isMin = false;

    public static ItemScript items = null;

    // Use this for initialization
    void Awake () {
        if (items == null)
            items = this;
        else if (items != this)
            Destroy(this.gameObject);

        //Use if you don't want to destroy between scenes.
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

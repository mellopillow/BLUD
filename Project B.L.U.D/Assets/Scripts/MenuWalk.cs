using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWalk : MonoBehaviour {

    public Animator animator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetInteger("Direction", 2);
        transform.position = new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z);
	}
}

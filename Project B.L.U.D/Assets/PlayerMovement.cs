using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public float maxSpeed;
    float smoothing, frames;
    Vector3 velocity;
    Rigidbody2D playerRB;
    

	void Start () {
        frames = 0;
        maxSpeed = .078f;
        playerRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (smoothing < 1)
            smoothing += .0207f;
        float h = Input.GetAxisRaw("Horizontal");
        if (h == 0){
            frames += 1;
            if (frames > 15){
                smoothing = .0207f;
                frames = 0;
            }
        }
        /*float v = Input.GetAxisRaw("Vertical");*/
        Move(h/*, v*/);
	}
    
    void Move(float h/*, float v*/){
        velocity.x = h * smoothing * maxSpeed;
        transform.Translate(velocity);
    }
}

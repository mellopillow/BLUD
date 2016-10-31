using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public float speed = 4;
    //public float gravity = -3;
    Vector3 velocity;
    Rigidbody2D playerRB;

	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
	}
    
    void Move(float h, float v) {
        velocity.x = h * speed/50;
        //velocity.y = gravity * Time.deltaTime;
        transform.Translate(velocity);
    }
}

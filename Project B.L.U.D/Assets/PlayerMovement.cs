using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public float speed = 4;
    public bool jumping = false;
    public float gravity = -1;
    Vector3 velocity;
    Rigidbody2D playerRB;
    Stopwatch s = new Stopwatch();

	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
	}
    
    void Move(float h, float v){
        velocity.x = h * speed/50;
        velocity.y = gravity * Time.deltaTime;
        transform.Translate(velocity);
    }

    void Jump(float v){
        if (v>0 && jumping == false)
        {
            s.Start();
            jumping = true;
            gravity = 0;
            velocity.y = v * speed/3;
            transform.Translate(velocity);
        }
        if(s.ElapsedMilliseconds > 200)
        {
            velocity.y = 0;
            gravity = -1;
        }
        if (s.ElapsedMilliseconds > 600)
        {
            s.Reset();
            jumping = false;
        }


    }
}

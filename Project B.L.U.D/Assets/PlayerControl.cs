using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public bool jump = false;
    public float jumpForce = 1000f;
    
    
    private bool grounded = false;
    private Transform groundCheck;

	// Use this for initialization
	void Awake () {
        groundCheck = transform.Find("groundCheck");
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
            jump = true;
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
        }

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (jump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

            jump = false;
        }
    }

    
}

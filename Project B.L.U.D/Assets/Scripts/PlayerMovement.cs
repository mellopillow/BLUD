using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public float MoveSpeed = .078f;
    float def;
    //float smoothing, frames;
    Vector3 velocity;
    Rigidbody2D playerRB;
    public Animator animator;
	public int spawnlocation = 0;
    public AudioClip footsteps;
    bool frozen;
    float timer = 0f;
    float FrozenTime = 0f;
    

	void Start () {
        //frames = 0;
        def = MoveSpeed;
        playerRB = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        //if (smoothing < 1)
        //    smoothing += .0207f;
        float h = Input.GetAxisRaw("Horizontal");
        //if (h == 0){
        /*   frames += 1;
            if (frames > 15){
                smoothing = .0207f;
                frames = 0;
            }
        }*/
        /*float v = Input.GetAxisRaw("Vertical");*/
        Move(h/*, v*/);
	}
    
    void Move(float h/*, float v*/){
        velocity.x = h * /*smoothing**/ MoveSpeed;
        transform.Translate(velocity);
		var d = Input.GetAxis("Horizontal");
        if (!frozen)
        {
            if (d < 0)
            {
                //left
                animator.SetInteger("Direction", 2);
            }
            else if (d > 0)
            {
                //right
                animator.SetInteger("Direction", 1);
            }
            else
            {
                animator.SetInteger("Direction", 0);
            }
        }
       
    }

    void PlaySound()
    {
        //audioManager.SetSFXVolume(.5f);
        AudioManager.instance.PlaySFXClip(footsteps, .6f);
    }

    public void freeze()
    {
        frozen = true;
        MoveSpeed = 0f;
    }
    public void unfreeze()
    {
        frozen = false;
        MoveSpeed = def;
    }
}

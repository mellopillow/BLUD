using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    // Use this for tialization
    public float speed;
    Animator animator;
    float def;
    float MoveSpeed;
    bool frozen;
    Rigidbody2D enemyRB;
    Vector3 velocity;
    Transform player, enemy;
    float h, h2, timer;
    
	void Start () {
        //animator = GetComponent<Animator>();   PUT THIS IN ONCE ENEMY HAS ANIMATOR
        timer = 0f;
        MoveSpeed = 0f;
        enemyRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        enemy = this.transform;
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        h = player.position.x;
        h2 = enemy.position.x;
        Move();
	}

    void Move()
    {
        if (!frozen && timer > .8f)
        {
            MoveSpeed = speed;
            def = speed;
        }

        if (h > h2)
        {
            if (ItemScript.current_light > h2)
            {
                MoveSpeed += 0.5f;
            }
            velocity.x = MoveSpeed;
        }
        else
        {
            if (ItemScript.current_light < h2)
            {
                MoveSpeed += 0.5f;
            }
            velocity.x = -MoveSpeed;
        }
        enemy.Translate(velocity);
    }

    public void freeze()
    {
        frozen = true;
        MoveSpeed = 0;
        //animator.SetInteger("Direction", 0);
    }
    public void unfreeze()
    {
        frozen = false;
        MoveSpeed = def;
    }

    void PlaySound()
    {
        //audioManager.SetSFXVolume(.5f);
        AudioManager.instance.PlaySFXClip(AudioManager.instance.sfx[1], .4f);
    }
}

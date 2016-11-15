using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    // Use this for tialization
    public float speed;
    Rigidbody2D enemyRB;
    Vector3 velocity;
    Transform player, enemy;
    float h, h2, timer;
    
	void Start () {
        timer = 0f;
        speed = .0f;
        enemyRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        enemy = this.transform;
        h = player.position.x;
        h2 = enemy.position.x;
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        Move();
	}

    void Move()
    {
        if (timer > .8f)
            speed = .082f;
        if (h > h2)
            velocity.x = speed;
        else
            velocity.x = -speed;
        enemy.Translate(velocity);
    }
}

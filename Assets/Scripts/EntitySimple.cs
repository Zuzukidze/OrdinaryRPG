using UnityEngine;
using System.Collections;

public class EntitySimple : EntityBase {
    RayCollider rc;
	// Use this for initialization
	void Start () {
        if (GetComponent<RayCollider>() != null)
            rc = GetComponent<RayCollider>();
        else
            Debug.Log("RayCollider is missing on" + gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
        SimpleAIUpdate();
	}
    void SimpleAIUpdate()
    {
        checkWalls();
        timer += Time.deltaTime;
        if (timer >= timeToChangeDirection)
        {
            ChangeDirection();
            timeToChangeDirection = Random.Range(0.5f, 1.5f);
            timer = 0;
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            switch (direction)
            {
                case Direction.right: rb.velocity = new Vector2(Speed, 0); break;
                case Direction.up: rb.velocity = new Vector2(0, Speed); break;
                case Direction.left: rb.velocity = new Vector2(-Speed, 0); break;
                case Direction.down: rb.velocity = new Vector2(0, -Speed); break;
            }
    }
    void checkWalls()
    {
        if (rc.collisionUp)
            ChangeDirection(Direction.down);
        else if (rc.collisionDown)
            ChangeDirection(Direction.up);
        else if (rc.collisionLeft)
            ChangeDirection(Direction.right);
        else if (rc.collisionRight)
            ChangeDirection(Direction.left);
    }
}

using UnityEngine;
using System.Collections;
using System;

public class MovableBlock : LogicElement {
    private Vector2 velocity = Vector2.zero;
    public float damp = 0.2f;
    private Vector2 target;
    //private Vector2 startpos;
    private bool isMoving = false;
    public Vector2 colCounter = Vector2.zero;
    public int CollisionCountRequired = 40;
    public float MovingOffset = 1;
    private RayCollider rc;
    // Use this for initialization
    void Start () {
        target = transform.position;
        rc = GetComponent<RayCollider>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isMoving)
        {
            transform.position = Vector2.SmoothDamp(transform.position, target, ref velocity, damp);
        }
        if (Math.Abs(transform.position.x - target.x) < 0.05f && Math.Abs(transform.position.y - target.y) < 0.05f)
        {
            isMoving = false;
            positionToArray();
        }
        checkIsPushing();
        checkColCounter();
    }
    void checkColCounter()
    {
        if (colCounter.x > CollisionCountRequired)
        {
            isMoving = true;
            target = new Vector2(transform.position.x + MovingOffset, transform.position.y);
            //startpos = transform.position;
            colCounter = Vector2.zero;
        }
        else if (colCounter.x < -CollisionCountRequired)
        {
            isMoving = true;
            target = new Vector2(transform.position.x - MovingOffset, transform.position.y);
            //startpos = transform.position;
            colCounter = Vector2.zero;
        }
        else if (colCounter.y > CollisionCountRequired)
        {
            isMoving = true;
            target = new Vector2(transform.position.x, transform.position.y + MovingOffset);
            //startpos = transform.position;
            colCounter = Vector2.zero;
        }
        else if (colCounter.y < -CollisionCountRequired)
        {
            isMoving = true;
            target = new Vector2(transform.position.x, transform.position.y - MovingOffset);
            //startpos = transform.position;
            colCounter = Vector2.zero;
        }
                
    }
    void checkIsPushing()
    {
        if (!rc.collisionLeft && rc.playerColRight && Input.GetAxis("Horizontal") < -0.1)
        {
            colCounter.x--;
        }
        else if (!rc.collisionRight && rc.playerColLeft && Input.GetAxis("Horizontal") > 0.1)
        {
            colCounter.x++;
        }
        else if (!rc.collisionUp && rc.playerColDown && Input.GetAxis("Vertical") > 0.1)
        {
            colCounter.y++;
        }
        else if (!rc.collisionDown && rc.playerColUp && Input.GetAxis("Vertical") < -0.1)
        {
            colCounter.y--;
        }
        else
            colCounter = Vector2.zero;
    }
    
}

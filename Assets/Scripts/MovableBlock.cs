using UnityEngine;
using System.Collections;
using System;

public class MovableBlock : LogicElement {
    private Vector2 velocity = Vector2.zero;
    public float damp = 0.2f;
    private Vector2 target;
    private Vector2 startpos;
    private Vector2 lastpos;
    private bool isMoving = false;
    public bool isOnIce = false;
    public Vector2 colCounter = Vector2.zero;
    public int CollisionCountRequired = 30;
    public int moveCount = 0;
    private Builder builder;
    // Use this for initialization
    void Start () {
        target = transform.position;
        startpos = transform.position;
        lastpos = transform.position;
        builder = GetComponent<Builder>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isMoving)
        {
            moveCount++;
            //transform.position = Vector2.SmoothDamp(transform.position, target, ref velocity, damp);
            GetComponent<Rigidbody2D>().velocity = (target - startpos)*2;
            if (lastpos.x == transform.position.x && lastpos.y == transform.position.y)
            {
                isMoving = false;
                positionToArray();
            }
        }
        if (Math.Abs(transform.position.x - target.x) < 0.05f && Math.Abs(transform.position.y - target.y) < 0.05f)
        {
            isMoving = false;
            positionToArray();
        }

        if (colCounter.x > CollisionCountRequired)
        {
            //if (GetComponent<BoxCollider2D>().IsTouchingLayers(0))
            isMoving = true;
            target = new Vector2(transform.position.x + 1, transform.position.y);
            startpos = transform.position;
            colCounter = Vector2.zero;
        }
        else if (colCounter.x < -CollisionCountRequired)
        {
            //if (GetComponent<BoxCollider2D>().IsTouchingLayers(0))
            isMoving = true;
            target = new Vector2(transform.position.x - 1, transform.position.y);
            startpos = transform.position;
            colCounter = Vector2.zero;
        }
        else if (colCounter.y > CollisionCountRequired)
        {
            //if (GetComponent<BoxCollider2D>().IsTouchingLayers(0))
            isMoving = true;
            target = new Vector2(transform.position.x, transform.position.y+1);
            startpos = transform.position;
            colCounter = Vector2.zero;
        }
        else if (colCounter.y < -CollisionCountRequired)
        {
            //if (GetComponent<BoxCollider2D>().IsTouchingLayers(0))
            isMoving = true;
            target = new Vector2(transform.position.x, transform.position.y-1);
            startpos = transform.position;
            colCounter = Vector2.zero;
        }
        lastpos = transform.position;
    }
    /*void OnCollisionEnter2D(Collider2D other)
    {
        isMoving = false;
        transform.position = startpos;
    }*/
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            if      (Input.GetAxis("Horizontal") >  0.1 && other.gameObject.transform.position.x < transform.position.x)
                colCounter.x++;
            else if (Input.GetAxis("Horizontal") < -0.1 && other.gameObject.transform.position.x > transform.position.x)
                colCounter.x--;
            else if (Input.GetAxis("Vertical") >    0.1 && other.gameObject.transform.position.y < transform.position.y)
                colCounter.y++;
            else if (Input.GetAxis("Vertical") <   -0.1 && other.gameObject.transform.position.y > transform.position.y)
                colCounter.y--;
            else
                colCounter = Vector2.zero;
        if (other.gameObject.tag == "Wallee")
            if (Input.GetAxis("Horizontal") > 0.1 && other.gameObject.transform.position.x > transform.position.x)
            {
                isMoving = false;
                colCounter = Vector2.zero;
                //builder.positionToArray();

            }
            else if (Input.GetAxis("Horizontal") < -0.1 && other.gameObject.transform.position.x < transform.position.x)
            {
                isMoving = false;
                colCounter = Vector2.zero;
                //builder.positionToArray();
            }
            else if (Input.GetAxis("Vertical") > 0.1 && other.gameObject.transform.position.y > transform.position.y)
            {
                isMoving = false;
                colCounter = Vector2.zero;
                //builder.positionToArray();
            }
            else if (Input.GetAxis("Vertical") < -0.1 && other.gameObject.transform.position.y < transform.position.y)
            {
                isMoving = false;
                colCounter = Vector2.zero;
                //builder.positionToArray();
            }
            else
                //builder.positionToArray();
        if (other.gameObject.tag == "Ice")
            isOnIce = true;
            }
}

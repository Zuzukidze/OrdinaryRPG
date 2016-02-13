using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float maxSpeed = 20f;
	private Animator anim;
	public float moveVer;
	public float moveHor;
    public bool isMovingBlock = false;
    public Vector2 lastvel = Vector2.zero;


	void Start () {
		anim = GetComponent<Animator>();
	}

	void FixedUpdate() {
	    moveVer = Input.GetAxis("Vertical");
	    moveHor = Input.GetAxis("Horizontal");
        if (Mathf.Abs(moveHor) < Mathf.Abs(moveVer))
        {
            anim.SetFloat("moveVer", moveVer);
            if (moveVer < -0.1f)
                anim.Play("downRun");
            if (moveVer > 0.1f)
                anim.Play("upRun");
        }
        else
        {
            anim.SetFloat("moveHor", moveHor);
            if (moveHor < -0.1f)
                anim.Play("leftRun");
            if (moveHor > 0.1f)
                anim.Play("rightRun");
        }
        Vector2 velocity = new Vector2(moveHor * maxSpeed, moveVer * maxSpeed);
        if (isMovingBlock)
            velocity *= 0.5f;
            GetComponent<Rigidbody2D>().velocity = velocity;
        lastvel = velocity;
	}
    
    void Update () {
	
	}
}

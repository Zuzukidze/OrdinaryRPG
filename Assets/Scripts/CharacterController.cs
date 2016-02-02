using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float maxSpeed = 20f;
	private Animator anim;
	private int dir = 0;
	public float moveVer;
	public float moveHor;
	public int isMV = 0, isMH = 0;

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

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveHor * maxSpeed, moveVer * maxSpeed);
	}

	void Update () {
	
	}
}

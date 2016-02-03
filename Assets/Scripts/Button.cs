using UnityEngine;
using System.Collections;
using System;

public class Button : MonoBehaviour {
    public bool isUpOnUnpressed = false;
    public LogicElement target;
    private bool isPressed = false;
    private Animator anim;
    private BoxCollider2D box;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isPressed)
        { 
            anim.Play("press");
            isPressed = true;
            target.Activate();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (isPressed && isUpOnUnpressed)
        {
            anim.Play("unpress");
            isPressed = false;
            target.Deactivate();
        }
    }
    [ContextMenu("SetPositionToArray")]
    private void positionToArray()
    {
        transform.position = new Vector3((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y));
    }
}

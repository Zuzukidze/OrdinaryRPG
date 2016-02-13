using UnityEngine;
using System.Collections;
using System;

public class Button : LogicElement {
    public bool isUpOnUnpressed = false;
    public int TimeBeforeUnpressing = 0;
    private float timer = 0;
    public LogicElement[] Targets;
    private bool isPressed = false;
    private Animator anim;
    private int pressers;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (pressers > 0)
        {
            Activate();
            timer = 0;
        }
        else {
            if (timer >= TimeBeforeUnpressing)
                Deactivate();
            else
                timer += Time.deltaTime;
        }
	}
    public override void Activate()
    {
        if (!isPressed)
        {
            anim.Play("press");
            isPressed = true;
            for (int i = 0; i < Targets.Length; i++)
            {
                if (Targets[i] != null) Targets[i].Activate();
                if (!isUpOnUnpressed) Targets[i].canDeactivate = false;
            }
        }
    }
    public override void Deactivate()
    {
        if (isPressed && isUpOnUnpressed)
        {
            anim.Play("unpress");
            isPressed = false;
            for (int i = 0; i < Targets.Length; i++)
                if (Targets[i] != null && Targets[i].canDeactivate) Targets[i].Deactivate();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            pressers++;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            pressers--;
        }
    }
}

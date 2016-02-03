using UnityEngine;
using System.Collections;

public class LogicGate : LogicElement {
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Activate()
    {
        anim.Play("Disappear");
        base.Activate();
    }
}

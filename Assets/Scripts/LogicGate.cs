using UnityEngine;
using System.Collections;

public class LogicGate : LogicElement {
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

    public override void Activate()
    {
        base.Activate();
        if (activatesCount >= HowManyActivatesNeed && !isActivated)
        {
            isActivated = true;
            anim.Play("Disappear");
        }
    }
    public override void Deactivate()
    {
        base.Deactivate();
        if (isActivated)
        {
            isActivated = false;
            anim.Play("Appear");
        }
    }
    [ContextMenu("Disable Collider")]
    private void DisableCollider()
    {
        box.enabled = false;
    }
    [ContextMenu("Enable Collider")]
    private void EnableCollider()
    {
        box.enabled = true;
    }
}

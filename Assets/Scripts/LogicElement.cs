using UnityEngine;
using System.Collections;
using System;

public abstract class LogicElement : MonoBehaviour {
    public bool canDeactivate = true; 
    public bool isActivated = false;
    public int HowManyActivatesNeed = 1;
    protected int activatesCount;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void Activate() {
        activatesCount++;
    }
    public virtual void Deactivate() {
        activatesCount--;
    }

    [ContextMenu("Destroy")]
    private void destroy()
    {
        Destroy(gameObject);
    }
    protected void positionToArray()
    {
        transform.position = new Vector3((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y));
    }
}

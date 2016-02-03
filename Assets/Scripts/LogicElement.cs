using UnityEngine;
using System.Collections;

public class LogicElement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void Activate() { }
    public void Deactivate() { }

    [ContextMenu("Destroy")]
    private void destroy()
    {
        Destroy(gameObject);
    }
}

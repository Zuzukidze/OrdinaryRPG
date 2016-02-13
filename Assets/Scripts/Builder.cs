using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class Builder : MonoBehaviour {
    public int width = 1;
    public int height = 1;
    public int offsetX = 0;
    public int offsetY = 0;

    void Start () {
    }
	
	void Update () {
	}
    [ContextMenu("Build")]
    private void build()
    {
        for (int y = 0; y<Math.Abs(height);y++)
            for (int x = 0;x< Math.Abs(width);x++)
                Instantiate(gameObject, new Vector3((transform.position.x + x + offsetX)* Math.Abs(width)/width, (transform.position.y + y + offsetY)* Math.Abs(height)/height, 0), Quaternion.identity);
    }
    [ContextMenu("SetPositionToArray")]
    public void positionToArray()
    {
        transform.position = new Vector3((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y));
    }
    public void XToArray()
    {
        transform.position = new Vector3((int)Math.Round(transform.position.x), transform.position.y);
    }
    public void YToArray()
    {
        transform.position = new Vector3(transform.position.x, (int)Math.Round(transform.position.y));
    }
}
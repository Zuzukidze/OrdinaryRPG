using UnityEngine;
using UnityEditor;
using System.Collections;

public class Builder : MonoBehaviour {
    public int width = 1;
    public int height = 1;

    void Start () {
    }
	
	void Update () {
	}
    [ContextMenu("CreateCubes")]
    private void build()
    {
        for (int y = 0; y<height;y++)
            for (int x = 0;x<width;x++)
                Instantiate(gameObject, new Vector3(x, y, 0), Quaternion.identity);
    }
}
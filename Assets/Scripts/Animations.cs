using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {

	public float u = 4f;
	public float v = 0.5f;
	public float FPS = 5F;
	public float DefOffset = -0.015F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float index = (int)(Time.time*FPS);
		index = index % (u * v);

		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (index * 0.25f - 0.015f, v);
	}
}

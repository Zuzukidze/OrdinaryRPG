using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	public int columsz = 4;
	public int rovsz = 4;
	public int fps = 5;
	public int rovSt = 0;
	public int colSt = 0;
	public int totalfr = 4;
	public float HorMove;
	public float VerMove;
	public float maxSpeed = 50f;
	public float xOff = 0.031f;
	public float Xoff = 0f;
	public float offs = 0f;
	bool walk = false;
	int dir = 0; //3 = down, 0 = left, 2 = right, 1 = up

	void FixedUpdate() {
		HorMove = Input.GetAxis ("Horizontal");
		VerMove = Input.GetAxis ("Vertical");
		GetComponent<Rigidbody2D>().velocity = new Vector2 (HorMove * maxSpeed*4f, VerMove * maxSpeed*4f);
	}

	void Update () {

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
						fps = 5;
			walk = true;
						if (Input.GetKey (KeyCode.A)) {
								rovSt = 0;
				dir = 1;
						} else if (Input.GetKey (KeyCode.D)) {
								rovSt = 2;
				dir = 3;
						}
				} else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.W)) {
						fps = 5;
			walk = true;
						if (Input.GetKey (KeyCode.W)) {
								rovSt = 1;
				dir = 2;
						} else if (Input.GetKey (KeyCode.S)) {
								rovSt = 3;
				dir = 0;
						}
				} else {
			walk = false;
						fps = 0;
			colSt = dir;
			rovSt = 4;
				}

		int frame = (int)(Time.time*fps);
		frame = frame % totalfr;
		int u = frame % columsz;
		int v = frame / columsz;
		Vector2 sze = new Vector2 (1.0f / columsz, 1.0f / rovsz);
		Vector2 offset = new Vector2 ((u + colSt) * sze.x, (1 - sze.y) - (v + rovSt) * sze.y);

		GetComponent<Renderer>().material.mainTextureOffset = offset;
		GetComponent<Renderer>().material.mainTextureScale = sze;
	}
}

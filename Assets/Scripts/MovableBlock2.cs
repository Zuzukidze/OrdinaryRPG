using UnityEngine;
using System.Collections;

public class MovableBlock2 : MonoBehaviour {
    private bool isMoving = false;
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        bool eIsPressed = Input.GetAxis("Action") > 0.1f;
        if (!eIsPressed)
            isMoving = false;
        if (isMoving)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().isMovingBlock = true;
            GetComponent<Rigidbody2D>().velocity = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().lastvel;
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;
            bool eIsPressed = Input.GetAxis("Action") > 0.1f;
            if (eIsPressed)
                isMoving = true;
            else
                isMoving = false;
        }
    }
}

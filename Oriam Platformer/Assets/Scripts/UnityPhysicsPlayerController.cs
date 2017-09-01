using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityPhysicsPlayerController : MonoBehaviour {

	public float movementSpeed;
	public float jumpSpeed;
	private InputState inputState;
	private Rigidbody2D body;

	public bool standing;

	// Use this for initialization
	void Start () {
		inputState = GetComponent<InputState> ();
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (inputState.rightButton) {
			body.AddForce (new Vector2 (movementSpeed, 0));
		}

		if (inputState.leftButton) {
			body.AddForce (new Vector2 (-movementSpeed, 0));
		}
		if (body.velocity.y == 0) {
			standing = true;
		} else {
			standing = false;
		}

		if (standing) {
			if (inputState.upButton) {
				body.AddForce (new Vector2 (0, jumpSpeed));

			}
		}

	}
}

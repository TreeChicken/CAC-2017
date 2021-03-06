using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Player control in 2D space
 */

namespace Player {
	public class Player2D : MonoBehaviour {
		Rigidbody2D rb;
		int mult = 30;

		void Start(){
			rb = transform.GetComponent<Rigidbody2D> ();
			rb.mass = 5;
		}

		protected virtual void FixedUpdate(){
			// Controls
			if (InputManager.instance.GO_FORWARD_CONT) {
				rb.AddForce (Vector2.up * mult*rb.mass);
			}
			if (InputManager.instance.TURN_RIGHT_CONT) {
				rb.AddForce (Vector2.right * mult*rb.mass);
			}
			if (InputManager.instance.GO_BACKWARD_CONT) {
				rb.AddForce (Vector2.down * mult*rb.mass);
			}
			if (InputManager.instance.TURN_LEFT_CONT) {
				rb.AddForce (Vector2.left * mult*rb.mass);
			}
		}
	}
}
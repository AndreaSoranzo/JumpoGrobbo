/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheWoddenLoft.Core;

namespace TheWoddenLoft.Player {
	public class PlayerMovement : MonoBehaviour {
		/* COMPONENTS */

		private Rigidbody2D rb;
		private SpriteRenderer sr;
		public PlayerPreferences playerPreferences;

		/* VARIABLES */
		[SerializeField] private float flipThreshold;

		private float positionX;
		private float camWidth;
		private float outOfBoundsX;

		void Start() {
			rb = GetComponent<Rigidbody2D>();
			sr = GetComponent<SpriteRenderer>();
			camWidth = Camera.main.aspect * 2f * Camera.main.orthographicSize;
			outOfBoundsX = camWidth/2;
		}

		private void Update() {

			if (positionX <= -flipThreshold) {
				sr.flipX = true;
			} else if (positionX >= flipThreshold) {
				sr.flipX = false;
			}

			if (IsOutOfView() == 1) {
				transform.position = new Vector2(-outOfBoundsX-.3f, transform.position.y);
			}
			else if (IsOutOfView() == -1) {
				transform.position = new Vector2(outOfBoundsX + .3f, transform.position.y);
			}
			else {
				return;
			}
		}

		private void FixedUpdate() {
			Move();
		}


		/* METHODS */
		#region METHODS

		public void SetMoveDirection (Vector2 moveDirection) {
			positionX = moveDirection.x;
		}

		private void Move() {
			Vector2 vel = rb.velocity;
			if (playerPreferences.isUsingTiltControls) {
				vel.x = positionX * playerPreferences.TLT_speed;
			}
			else{
				vel.x = positionX * playerPreferences.TOUCH_speed;
			}
			rb.velocity = vel;
		}

		private int IsOutOfView() {
			float viewportPositionX = Camera.main.WorldToViewportPoint(transform.position).x;
			if (viewportPositionX > 1.1f) {
				return 1;
			}
			if (viewportPositionX < -.1f) {
				return -1;
			}
			return 0;
		}
		#endregion
	}
}
/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheWoddenLoft.Core;
using System;

namespace TheWoddenLoft.Player {
	public class PlayerJump : MonoBehaviour {
		/* COMPONENTS */
		private Rigidbody2D rb;
		private AudioSource audioSource;

		/* VARIABLES */
		[SerializeField] private float jumpForce;
		[SerializeField] private float firstJumpMultiplier;

		private const string PLATFORM_TAG = "Platform";

		private bool canSuperJump = true;

		private void Start() {
			rb = GetComponent<Rigidbody2D>();
			audioSource = GetComponent<AudioSource>();
		}

		private void OnCollisionEnter2D(Collision2D collision) {
			if (collision.relativeVelocity.y >= 0 && collision.gameObject.CompareTag(PLATFORM_TAG)) {
				if (GameManager.instance.gameState == GameState.PLAYING && canSuperJump) {
					canSuperJump = false;
					Jump(firstJumpMultiplier);
					audioSource.PlayOneShot(audioSource.clip);
				} else {
					Jump(1);
					audioSource.PlayOneShot(audioSource.clip);
				}
			}
		}


		/* METHODS */
		#region METHODS

		private void Jump(float multiplier) {
			Vector2 vel = rb.velocity;
			vel.y = jumpForce*multiplier;
			rb.velocity = vel;
		}

		#endregion
	}
}
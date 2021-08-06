/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheWoddenLoft.Core;

namespace TheWoddenLoft.Player {
	public class InputManager : MonoBehaviour {

		[SerializeField] private PlayerMovement playerMovement;

		private void Update() {
			if (GameManager.instance.gameState == GameState.PLAYING) {
				if (playerMovement.playerPreferences.isUsingTiltControls) {
					UsingTiltContols();
				}
				else {
					UsingTouch();
				}
			}
		}

		/* METHODS */
		#region METHODS

		private void UsingTouch() {
			Vector2 position = new Vector2();
			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch(0);
				position = Camera.main.ScreenToWorldPoint(touch.position);
			} else {
				position = Vector3.Lerp(position, Vector3.zero, 0.01f * Time.deltaTime);
			}
			playerMovement.SetMoveDirection(position);
		}
		private void UsingTiltContols() {  
			Vector3 acceleration = Input.acceleration;
			acceleration = Vector3.Lerp(acceleration, Input.acceleration, 0.4f * Time.deltaTime);
			playerMovement.SetMoveDirection(acceleration);
		}

		#endregion

	}
}
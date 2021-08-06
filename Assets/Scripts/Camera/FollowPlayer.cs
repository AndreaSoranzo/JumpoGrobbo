/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheWoddenLoft.Core;

namespace TheWoodenLoft.Camera {
	public class FollowPlayer : MonoBehaviour {
		/* COMPONENTS */
		[SerializeField] private GameObject player;

		void LateUpdate() {
			if (GameManager.instance.gameState == GameState.PLAYING) {
				Vector3 camPosition = transform.position;
				camPosition.y = Mathf.Lerp(transform.position.y, player.transform.position.y, 2 * Time.deltaTime);
				transform.position = camPosition;
			}
		}

		/* METHODS */
		#region METHODS



		#endregion
	}
}
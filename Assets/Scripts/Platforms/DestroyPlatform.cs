/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheWoddenLoft.Platforms {
	public class DestroyPlatform : MonoBehaviour {

		[SerializeField] private float despownPoint;

		void Update() {
			if (IsOutOfView()) {
				Destroy(gameObject);
			}
		}

		/* METHODS */
		#region METHODS

		private bool IsOutOfView() {
			float viewportPositionY = Camera.main.WorldToViewportPoint(transform.position).y;
			if (viewportPositionY < despownPoint) {
				return true;
			}
			return false;
		}

		#endregion
	}
}
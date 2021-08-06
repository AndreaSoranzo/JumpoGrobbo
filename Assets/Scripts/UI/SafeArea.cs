/*
* Script made by Jay
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheWoodenLoft.UI {
	public class SafeArea : MonoBehaviour {
		/* COMPONENTS */
		private RectTransform rectTransform;

		/* VARIABLES */
		private Rect safeArea;
		private Vector2 minAnchor;
		private Vector2 maxAnchor;

		private void Awake() {
			rectTransform = GetComponent<RectTransform>();
			ApplySafeArea();
		}

		private void Update() {
			if (safeArea != Screen.safeArea) {
				ApplySafeArea();
			}
		}

		/* METHODS */
		#region METHODS

		private void ApplySafeArea() {
			safeArea = Screen.safeArea;
			minAnchor = safeArea.position;
			maxAnchor = minAnchor + safeArea.size;

			minAnchor.x /= Screen.width;
			minAnchor.y /= Screen.height;
			maxAnchor.x /= Screen.width;
			maxAnchor.y /= Screen.height;
			

			rectTransform.anchorMin = minAnchor;
			rectTransform.anchorMax = maxAnchor;
		}

		#endregion
	}
}
/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using TheWoddenLoft.Core;
using UnityEngine;

namespace TheWoodenLoft.UI.Controls {
	public class ControllerToggle : MonoBehaviour {
		/* COMPONENTS */
		private RectTransform toggle;
		[SerializeField] private PlayerPreferences playerPreferences;

		/* VARIABLES */


		void Start() {
			toggle = GetComponent<RectTransform>();
			if (!playerPreferences.isUsingTiltControls) {
				Invert();
			}
		}

		private void Invert() {
			Vector2 temp = toggle.anchoredPosition;
			temp.x *= -1;
			toggle.anchoredPosition = temp;
		}
	}
}
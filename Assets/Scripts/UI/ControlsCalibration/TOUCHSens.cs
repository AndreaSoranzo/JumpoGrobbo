/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TheWoddenLoft.Core;

namespace TheWoodenLoft.UI.Controls {
	public class TOUCHSens : MonoBehaviour,ISensButton {
		private TextMeshProUGUI label;
		[SerializeField] private PlayerPreferences playerPreferences;

		/* VARIABLES */
		private float touch;
		private float increaseAmount = 0.5f;

		void Start() {
			label = GetComponent<TextMeshProUGUI>();
			touch = playerPreferences.TOUCH_speed;
			label.text = touch.ToString();
		}
		/* METHODS */
		#region METHODS

		public void Increase() {
			touch += increaseAmount;
			touch = Mathf.Clamp(touch, 0, 10);
			label.text = touch.ToString();
			playerPreferences.TOUCH_speed = touch;
		}

		public void Decrease() {
			touch -= increaseAmount;
			touch = Mathf.Clamp(touch, 0, 10);
			label.text = touch.ToString();
			playerPreferences.TOUCH_speed = touch;
		}

		#endregion
	}
}
/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TheWoddenLoft.Core;

namespace TheWoodenLoft.UI.Controls {
	public class TLTSens : MonoBehaviour,ISensButton {
		/* COMPONENTS */
		private TextMeshProUGUI label;
		[SerializeField] private PlayerPreferences playerPreferences;

		/* VARIABLES */
		private float tlt;
		private float increaseAmount = 0.5f;

		void Start() {
			label = GetComponent<TextMeshProUGUI>();
			tlt = playerPreferences.TLT_speed;
			label.text = tlt.ToString();
		}
		/* METHODS */
		#region METHODS

		public void Increase() {
			tlt += increaseAmount;
			tlt = Mathf.Clamp(tlt, 5,15);
			label.text = tlt.ToString();
			playerPreferences.TLT_speed = tlt;
		}

		public void Decrease() {
			tlt -= increaseAmount;
			tlt = Mathf.Clamp(tlt, 5, 15);
			label.text = tlt.ToString();
			playerPreferences.TLT_speed = tlt;
		}

		#endregion
	}
}
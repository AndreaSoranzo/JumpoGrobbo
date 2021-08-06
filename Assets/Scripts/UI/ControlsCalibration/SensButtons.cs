/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheWoodenLoft.UI.Controls {
	public class SensButtons : MonoBehaviour {
		/* COMPONENTS */
		[SerializeField] private GameObject display;
		private ISensButton sensButton;

		/* VARIABLES */

		private void Start() {
			sensButton = display.GetComponent<ISensButton>();
		}

		public void IncreaseValue() {
			if (sensButton != null) {
				sensButton.Increase();
			}
		}

		public void DecreaseValue() {
			if (sensButton != null) {
				sensButton.Decrease();
			}
		}

	}
}

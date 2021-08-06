/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheWoddenLoft.Core;

namespace TheWoddenLoft.Managers {
	public class SaveLoadManager : MonoBehaviour {
		/* COMPONENTS */
		[SerializeField] private PlayerPreferences playerPreferences;
		[SerializeField] private AudioManager audioManager;

		/* VARIABLES */

		private void Awake() {
			LoadPrefs();
		}

		public void SaveGamePrefs() {
			PlayerPrefs.SetFloat("TLT_speed", playerPreferences.TLT_speed);
			PlayerPrefs.SetFloat("TOUCH_speed", playerPreferences.TOUCH_speed);
			PlayerPrefs.SetInt("isUsingTiltControls", BoolToInt(playerPreferences.isUsingTiltControls));
			PlayerPrefs.SetFloat("MusicValue", audioManager.musicSlider.value);
			PlayerPrefs.SetFloat("SFXValue", audioManager.SFXSlider.value);
			PlayerPrefs.Save();
		}

		private void LoadPrefs() {
			if (PlayerPrefs.HasKey("isUsingTiltControls")) {
				playerPreferences.TLT_speed = PlayerPrefs.GetFloat("TLT_speed");
				playerPreferences.TOUCH_speed = PlayerPrefs.GetFloat("TOUCH_speed");
				playerPreferences.isUsingTiltControls = IntToBool(PlayerPrefs.GetInt("isUsingTiltControls"));
				audioManager.musicSlider.value = PlayerPrefs.GetFloat("MusicValue");
				audioManager.SFXSlider.value = PlayerPrefs.GetFloat("SFXValue");
			}
		}

		private int BoolToInt(bool vaule) {
			if (vaule) {
				return 1;
			}
			else {
				return 0;
			}
		}

		private bool IntToBool(int vaule) {
			if (vaule == 1) {
				return true;
			}
			else {
				return false;
			}
		}
	}
}
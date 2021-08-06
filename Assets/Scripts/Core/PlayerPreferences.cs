/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheWoddenLoft.Core {
	[CreateAssetMenu(fileName = "PlayerPrefernces", menuName = "ScriptableObjects/PlayerPrefernces")]
	public class PlayerPreferences : ScriptableObject {
		public float TLT_speed = 8;
		public float TOUCH_speed = 3;
		public bool isUsingTiltControls = true;

		public void ChangeContols() {
			isUsingTiltControls = !isUsingTiltControls;
		}
	}
}
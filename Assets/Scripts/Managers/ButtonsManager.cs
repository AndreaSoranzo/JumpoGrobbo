/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TheWoddenLoft.Core;

namespace TheWoddenLoft.Managers {
	public class ButtonsManager : MonoBehaviour {

		public void StartGame() {
			GameManager.instance.StartGame();
		}

		public void RetryGame() {
			GameManager.instance.Retry();
		}

		public void GoToMainMenu() {
			GameManager.instance.GoMainMenu();
		}
		public void CloseGame() {
			Application.Quit();
		}
	}
}
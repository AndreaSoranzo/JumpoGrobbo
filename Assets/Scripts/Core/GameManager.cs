/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace TheWoddenLoft.Core {
	public class GameManager : MonoBehaviour {

		public static GameManager instance { get; private set; }
		public event Action OnGameOver;

		/* VARIABLES */
		public GameState gameState { get; private set; }
		public bool gameHasBeenRestarted { get; private set; }

		private const float DELAY = 1;

		private void Awake() {   
			if (instance == null) {
				Screen.sleepTimeout = SleepTimeout.NeverSleep;
				Input.multiTouchEnabled = false;
				instance = this;
				DontDestroyOnLoad(gameObject);
			} else {
				Destroy(gameObject);
			}
		}

		private void Start() {
			gameState = GameState.MENU;
		}

		/* METHODS */
		#region METHODS

		public void StartGame() {
			gameState = GameState.PLAYING;
		}
		public void Retry() {
			StartCoroutine(WaitForTransitionRetry());
		}

		public void GoMainMenu() {
			StartCoroutine(WaitForTransitionRetryMenu());
		}

		public void End() {
			gameState = GameState.GAMEOVER;
			OnGameOver?.Invoke();
		}
		#endregion

		private IEnumerator WaitForTransitionRetry() {
			yield return new WaitForSeconds(DELAY);
			gameHasBeenRestarted = true;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			gameState = GameState.PLAYING;
		}

		private IEnumerator WaitForTransitionRetryMenu() {
			yield return new WaitForSeconds(DELAY);
			gameHasBeenRestarted = false;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			gameState = GameState.MENU;
		}
	}
}

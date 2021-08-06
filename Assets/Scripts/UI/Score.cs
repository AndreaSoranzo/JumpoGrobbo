/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TheWoddenLoft.Core;

namespace TheWoodenLoft.UI {
	public class Score : MonoBehaviour {
		/* COMPONENTS */
		[SerializeField] public Transform player;
		[SerializeField] TextMeshProUGUI highScoreDisplay;
		private TextMeshProUGUI scoreLabel;

		/* VARIABLES */
		public int maxScore { get; private set; } =  0;

		void Start() {
			GameManager.instance.OnGameOver += DisplayHighScore;
			scoreLabel = GetComponent<TextMeshProUGUI>();
		}

		void Update() {
			if (player.transform.position.y > 0) {
				if (player.transform.position.y > maxScore) {
					maxScore = (int)player.transform.position.y;
					scoreLabel.text = maxScore.ToString();
				}
			}
		}

		private void OnDestroy() {
			GameManager.instance.OnGameOver -= DisplayHighScore;
		}

		/* METHODS */
		#region METHODS

		private void DisplayHighScore() {
			highScoreDisplay.text += maxScore.ToString();
		}

		#endregion
	}
}
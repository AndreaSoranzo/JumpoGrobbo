/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TheWoddenLoft.Core;

namespace TheWoodenLoft.UI.Tweening {
	public class Tween_Score : MonoBehaviour {
		/* COMPONENTS */
		private CanvasGroup scoreWindow;

		/* VARIABLES */
		[SerializeField] private float fadeValue;
		[SerializeField] private float fadeDuration;
		[SerializeField] private Ease fadeEase;

		private void Start() {
			scoreWindow = GetComponent<CanvasGroup>();
			if (GameManager.instance.gameHasBeenRestarted) {
				ShowScore();
			}
		}

		public void ShowScore() {

			scoreWindow.DOFade(fadeValue, fadeDuration).SetEase(fadeEase);
		}
	}
}
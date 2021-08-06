/*
* Script made by Jay
*/

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheWoddenLoft.Core;

namespace TheWoodenLoft.UI.Tweening {
	public class Tween_MainMenu : MonoBehaviour {
		/* COMPONENTS */
		private CanvasGroup mainWindow;

		/* VARIABLES */
		[SerializeField] private float fadeValue;
		[SerializeField] private float fadeDuration;
		[SerializeField] private Ease fadeEase;

		private void Awake() {
			DOTween.Init();
		}
		private void Start() {
			mainWindow = GetComponent<CanvasGroup>();
			if (GameManager.instance.gameHasBeenRestarted) {
				gameObject.SetActive(false);
			}
		}

		public void HideMenu() {
			mainWindow.interactable = false;
			mainWindow.blocksRaycasts = false;
			mainWindow.DOFade(fadeValue, fadeDuration).SetEase(fadeEase);
		}
	}
}
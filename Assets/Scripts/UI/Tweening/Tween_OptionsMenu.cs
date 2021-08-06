/*
* Script made by Jay
*/

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheWoodenLoft.UI.Tweening {
	public class Tween_OptionsMenu : MonoBehaviour {
		/* COMPONENTS */
		private RectTransform rectTransform;
		[SerializeField] private CanvasGroup mainWindow;

		/* VARIABLES */
		[Header("Animation")]
		[SerializeField] private float animarionDuration;
		[SerializeField] private Ease animationEase;

		[Header("Fade")]
		[SerializeField] private float fadeValue;
		[SerializeField] private float fadeDuration;
		[SerializeField] private Ease fadeEase;
		private float offset;

		private void Start() {
			rectTransform = GetComponent<RectTransform>();
			offset = Mathf.Abs(rectTransform.anchoredPosition.x);
		}

		public void OpenSettingWindow() {
			mainWindow.DOFade(fadeValue, fadeDuration).SetEase(fadeEase);
			rectTransform.DOLocalMoveX(rectTransform.anchoredPosition.x + offset, animarionDuration).SetEase(animationEase);
		}

		public void CloseSettingWindow() {
			mainWindow.DOFade(1, fadeDuration).SetEase(fadeEase);
			rectTransform.DOLocalMoveX(rectTransform.anchoredPosition.x - offset, animarionDuration).SetEase(animationEase);
		}

		/* METHODS */
		#region METHODS



		#endregion
	}
}
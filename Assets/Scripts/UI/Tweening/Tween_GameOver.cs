/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheWoddenLoft.Core;
using DG.Tweening;

namespace TheWoodenLoft.UI.Tweening {
	public class Tween_GameOver : MonoBehaviour {
		/* COMPONENTS */
		private RectTransform rectTransform;

		/* VARIABLES */
		[SerializeField] private float animarionDuration;
		[SerializeField] private Ease animationEase;
		private float offset;

		void Start() {
			GameManager.instance.OnGameOver += OpenGameOverPanel;
			rectTransform = GetComponent<RectTransform>();
			offset = Mathf.Abs(rectTransform.anchoredPosition.y);
		}

		private void OnDestroy() {
			GameManager.instance.OnGameOver -= OpenGameOverPanel;
		}

		/* METHODS */
		#region METHODS

		private void OpenGameOverPanel() {
			rectTransform.DOLocalMoveY(rectTransform.anchoredPosition.y - offset, animarionDuration).SetEase(animationEase);
		}

		public void CloseGameOverPanel() {
			rectTransform.DOLocalMoveY(rectTransform.anchoredPosition.y + offset, animarionDuration/2).SetEase(animationEase);
		}

		#endregion
	}
}
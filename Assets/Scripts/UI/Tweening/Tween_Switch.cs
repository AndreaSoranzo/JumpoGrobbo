/*
* Script made by Jay
*/

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheWoodenLoft.UI.Tweening {
	public class Tween_Switch : MonoBehaviour {
		/* COMPONENTS */
		private RectTransform toggle;

		/* VARIABLES */
		[SerializeField] private float duration;
		[SerializeField] private Ease ease;

		private void Start() {
			toggle = GetComponent<RectTransform>();
		}
		public void OnChange() {
			toggle.DOLocalMoveX(toggle.anchoredPosition.x * -1,duration).SetEase(ease);
		}

	}
}
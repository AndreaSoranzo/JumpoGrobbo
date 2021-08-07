/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace TheWoodenLoft.Camera {
	public class WaitIntro : MonoBehaviour {
		/* COMPONENTS */
		[SerializeField] private VideoPlayer videoPlayer;

		private void Start() {
			videoPlayer.started += Wait;
		}

		private void Wait(VideoPlayer videoPlayer) {
			StartCoroutine(WaitForVideoEnd());
		}

		private IEnumerator WaitForVideoEnd() {
			yield return new WaitForSeconds((float)videoPlayer.length+1);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		private void OnDisable() {
			videoPlayer.started -= Wait;
		}
	}
}
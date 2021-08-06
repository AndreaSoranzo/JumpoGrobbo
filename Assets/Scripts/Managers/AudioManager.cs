/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TheWoddenLoft.Core;

namespace TheWoddenLoft.Managers {
	public class AudioManager : MonoBehaviour {

		/* COMPONENTS */
		[Header("AMBIENT MUSIC")]
		[SerializeField] private AudioSource ambientMusic;
		public Slider musicSlider;

		[Header("SFX")]
		[SerializeField] private AudioSource playerSFX;
		public Slider SFXSlider;

		/* VARIABLES */
		[SerializeField] private AudioClip[] clips;

		void Start() {
			GameManager.instance.OnGameOver += PlayDeathSFX;
			ambientMusic.volume = musicSlider.value;
			playerSFX.volume = SFXSlider.value;

			if (GameManager.instance.gameHasBeenRestarted) {
				PlayGameSong();
			} else {
				PlayMenuSong();
			}
		}

		private void OnDestroy() {
			GameManager.instance.OnGameOver -= PlayDeathSFX;
		}

		/* METHODS */
		#region METHODS

		private void PlayMenuSong() {
			ambientMusic.Stop();
			ambientMusic.clip = clips[0];
			ambientMusic.Play();
		}

		public void PlayGameSong() {
			ambientMusic.Stop();
			ambientMusic.clip = clips[1];
			ambientMusic.Play();
		}

		public void MuteUnMute() {
			ambientMusic.mute = !ambientMusic.mute;
			playerSFX.mute = !playerSFX.mute;
		}

		private void PlayDeathSFX() {
			ambientMusic.Stop();
			ambientMusic.PlayOneShot(clips[2]);
		}

		public void MusicVolume(float value) {
			ambientMusic.volume = value;
		}
		public void SFXVolume(float value) {
			playerSFX.volume = value;
		}

		#endregion
	}
}
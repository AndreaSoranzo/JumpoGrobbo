/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using TheWoddenLoft.Core;
using UnityEngine;

namespace TheWoddenLoft.Managers {
	public class PlatformGeneratorManager : MonoBehaviour {
		/* COMPONENTS */
		[Header("COMPONENTS")]
		[SerializeField] private GameObject platform;
		[SerializeField] private Transform player;
		[SerializeField] private Transform parent;

		/* VARIABLES */
		[Header("VARIABLES")]
		[SerializeField] private int density;
		[SerializeField] private float topExtraBound;
		[SerializeField] private float spownOffset;
		[SerializeField] private float minInterval;
		[SerializeField] private float maxInterval;
		[SerializeField] private float borderThicc;
		private float camHeight;
		private float camWidth;
		private float limitX;
		private float spownArea;
		private float lastPlatformPosition;



		void Start() {
			camHeight = 2f * Camera.main.orthographicSize;
			camWidth = Camera.main.aspect * camHeight;
			limitX = Mathf.Round(camWidth / 2);
			spownArea = Mathf.Round(camHeight / 2) + topExtraBound;
			GeneratePlatform();
		}

		void Update() {
			if (GameManager.instance.gameState == GameState.PLAYING) {
				if (player.transform.position.y > spownArea - topExtraBound) {
					GeneratePlatform();
					spownArea += topExtraBound;
				}
			}
		}

		/* METHODS */
		#region METHODS

		private void GeneratePlatform() {
			Vector2 spownPos = new Vector2();
			spownPos.y = lastPlatformPosition - spownOffset;
			for (int i = 0; i < density; i++) {
				spownPos.x = Random.Range(-limitX + borderThicc, limitX - borderThicc);
				spownPos.y += Random.Range(minInterval, maxInterval);
				if (spownPos.y > spownArea + topExtraBound) {
					return;
				}
				lastPlatformPosition = spownPos.y;
				Instantiate(platform, spownPos, Quaternion.identity, parent);
			}
		}

		#endregion
	}
}
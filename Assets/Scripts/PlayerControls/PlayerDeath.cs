/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheWoddenLoft.Core;

namespace TheWoddenLoft.Player {
	public class PlayerDeath : MonoBehaviour {

		[SerializeField] private Rigidbody2D player;

		private void OnTriggerEnter2D(Collider2D collision) {
			player.constraints = RigidbodyConstraints2D.FreezeAll;
			GameManager.instance.End();
		}

	}
}
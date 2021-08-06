/*
* Script made by Jay
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheWoddenLoft.Transitions {
	public class InGameTransitions : MonoBehaviour {
		/* COMPONENTS */
		[SerializeField] private Animator animator;
		[SerializeField] private AnimationClip transitionIN;
		[SerializeField] private AnimationClip transitionOUT;


		public void PlayTransitionIN() {
			animator.Play(transitionIN.name);
		}

		public void PlayTransitionOUT() {
			animator.Play(transitionOUT.name);
		}

	}
}
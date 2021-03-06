using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Managers;

/*
 * Displays img screen
 * Screen set in dialogue with <portrait>:##:<text> where ## is the portrait index and <text> is the dialogue
 */

namespace GameUI{
	public class ImgScreen : MonoBehaviour {
		public Sprite[] screens;

		private int currentPortrait = 0;

		public void SetScreen(int n){

			if(currentPortrait != n){
				GameManager.instance.FadeFromBlack ();
			}

			transform.GetComponent<Image> ().sprite = screens [n];
			currentPortrait = n;
		}
	}
}

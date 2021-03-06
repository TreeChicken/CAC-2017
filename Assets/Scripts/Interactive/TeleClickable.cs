using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI;
using Managers;

/*
 * Clickable portal
 */

namespace Interactive{
	public class TeleClickable : Clickable {
		public string targetRoom;
		public AudioClip moveSound;
		public string[] conds;

		override public void OnMouseDown(){
			if (GameState.state == GameState.State.OPEN && CondSatisfied()) {
				MoveToFloor ();
			}
		}

		protected virtual void MoveToFloor() {
			SoundManager.instance.PlaySFX (moveSound, 3);

			GameManager.instance.FadeFromBlack ();
			GameManager.instance.HideDisp ();
			GameManager.instance.GoTo (targetRoom);

			GameState.state = GameState.State.OPEN;
			GameState.lookingAt = -1;
		}

		// Checks if conditions are satisfied for passing
		bool CondSatisfied(){
			foreach(string s in conds){
				if ((int)InventorySystem.instance.GetType ().GetField (s).GetValue (InventorySystem.instance) == 0) {
					return false;
				}
			}

			return true;
		}
	}
}
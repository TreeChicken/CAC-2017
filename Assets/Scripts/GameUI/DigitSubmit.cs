using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

/*
 * Combo lock submission button
 */

namespace GameUI {
	public class DigitSubmit : MonoBehaviour {
		public DigitCounter[] digits;
		public int[] code;

		public void Verify(){
			for (int i=0; i < digits.Length; i++) {
				if(digits[i].Val != code[i]){
					foreach(DigitCounter d in digits){
						d.Revert ();
					}
					return;
				}
			}

			//Solved
			Solve();
		}

		void Solve(){
			// TODO: Write stuff to happen when solved

			// TEMP
			GameManager.instance.GoTo("2Droom01");
			GameState.state = GameState.State.OPEN;
		}
	}
}
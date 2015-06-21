/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* PlayerController.cs : Controls the player's input keys
*----------------------------------------------------------------
*/
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public static readonly int UP_TRANSITION = 1;
	public static readonly int RIGHT_TRANSITION = 2;
	public static readonly int DOWN_TRANSITION = 3;
	public static readonly int LEFT_TRANSITION = 4;

	public void Update () {
		if (GameManager.Instance.matchStarted) {
			if (Input.GetButtonDown ("Up")) {
				EvaluateMove.Instance.UserInputKey (UP_TRANSITION);
				Debug.Log ("UP was pressed", gameObject);
			}
			if (Input.GetButtonDown ("Right")) {
				EvaluateMove.Instance.UserInputKey (RIGHT_TRANSITION);
				Debug.Log ("RIGHT was pressed", gameObject);
			}
			if (Input.GetButtonDown ("Down")) {
				EvaluateMove.Instance.UserInputKey (DOWN_TRANSITION);
				Debug.Log ("DOWN was pressed", gameObject);
			}		
			if (Input.GetButtonDown ("Left")) {
				EvaluateMove.Instance.UserInputKey (LEFT_TRANSITION);
				Debug.Log ("LEFT was pressed", gameObject);
			}
		}
	}
}

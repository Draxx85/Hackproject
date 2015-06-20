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

public class PlayerController : MonoBehaviour
{
	public const int UP_TRANSITION = 1;
	public const int RIGHT_TRANSITION = 2;
	public const int DOWN_TRANSITION = 3;
	public const int LEFT_TRANSITION = 4;

	void Update ()
	{
		if (GameManager.Instance.matchStarted) {
			if (Input.GetButtonDown ("Up")) {
				EvaluateMove.Instance.userInputKey (UP_TRANSITION);
				Debug.Log ("UP was pressed", gameObject);
			}
			if (Input.GetButtonDown ("Right")) {
				EvaluateMove.Instance.userInputKey (RIGHT_TRANSITION);
				Debug.Log ("RIGHT was pressed", gameObject);
			}
			if (Input.GetButtonDown ("Down")) {
				EvaluateMove.Instance.userInputKey (DOWN_TRANSITION);
				Debug.Log ("DOWN was pressed", gameObject);
			}		
			if (Input.GetButtonDown ("Left")) {
				EvaluateMove.Instance.userInputKey (LEFT_TRANSITION);
				Debug.Log ("LEFT was pressed", gameObject);
			}
		}
	}
}

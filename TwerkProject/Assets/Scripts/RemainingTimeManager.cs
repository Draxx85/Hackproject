/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* RemainingTimeManager.cs : Counts down and tracks the remaing time so that the game can end
*----------------------------------------------------------------
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RemainingTimeManager : MonoBehaviour
{
	private Text text;
	private float deltaTime = 0.0f;
	private int countDownEndSeconds = 0;
	public int endCountdownTime = 120;
	
	void Awake ()
	{
		text = GetComponent <Text> ();
		deltaTime = Time.time;
		countDownEndSeconds = endCountdownTime;
		text.text = "";
	}
	
	void Update ()
	{
		// Change the remaining time
		if (Time.time - deltaTime >= 1.0f) {
			deltaTime = Time.time;

			if (GameManager.Instance.matchStarted) {
				countDownEndSeconds--;
			}
		}
		
		
		if (GameManager.Instance.matchStarted) {
			text.text = "Time Remaining: " + countDownEndSeconds;
		}

		// If the game is over
		if (countDownEndSeconds <= 0) {
			GameManager.Instance.EndGame ();
		}
	}
}
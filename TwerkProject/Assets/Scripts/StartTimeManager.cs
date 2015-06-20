/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* StartTimeManager.cs : Counts down and tracks the start time so that the game can start
*----------------------------------------------------------------
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartTimeManager : MonoBehaviour
{
	private Text text;
	private float deltaTime = 0.0f;
	private int countDownStartSeconds = 0;

	public int startCountdownTime = 4;
	public string startText = "TWERK";
	
	void Awake ()
	{
		text = GetComponent <Text> ();
		deltaTime = Time.time;
		countDownStartSeconds = startCountdownTime;
	}
	
	void Update ()
	{
		// Change the remaining time
		if (Time.time - deltaTime >= 1.0f) {
			deltaTime = Time.time;

			if (!GameManager.Instance.matchStarted) {
				countDownStartSeconds--;
			}
		}

		// If the game started		
		if (countDownStartSeconds <= 0) {
			GameManager.Instance.StartGame ();
		}
		
		if (!GameManager.Instance.matchStarted) {
			if (countDownStartSeconds == 1) {
				text.text = startText;
			} else {
				text.text = (countDownStartSeconds - 1).ToString ();
			}
		} else {
			text.text = "";
		}
	}
}
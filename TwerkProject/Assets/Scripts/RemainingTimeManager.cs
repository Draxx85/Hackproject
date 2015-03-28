﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RemainingTimeManager : MonoBehaviour
{
	private Text text;
	private float deltaTime = 0.0f;
	private int countDownSeconds = 0;
	
	public int startCountdownTime = 90;
	
	void Awake ()
	{
		text = GetComponent <Text> ();
		deltaTime = Time.time;
		countDownSeconds = startCountdownTime;
	}
	
	void Update ()
	{
		// Change the remaining time
		if (Time.time - deltaTime >= 1.0f) {
			deltaTime = Time.time;
			countDownSeconds--;
		}

		// If the game is over
		if (countDownSeconds <= 0) {
			GameManager.Instance.EndGame();
		}

		text.text = "Time Remaining: " + countDownSeconds;
	}
}
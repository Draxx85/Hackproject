using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RemainingTimeManager : MonoBehaviour
{
	private Text text;
	private float startTime = 0.0f;
	private float countDownSeconds = 0.0f;
	
	public float startCountdownTime = 90.0f;
	
	void Awake ()
	{
		text = GetComponent <Text> ();
		startTime = Time.time;
		countDownSeconds = startCountdownTime;
	}
	
	void Update ()
	{
		// Change the remaining time
		if (Time.time - startTime >= 1) {
			startTime = Time.time;
			countDownSeconds--;
		}

		text.text = "Time Remaining: " + countDownSeconds;
	}
}
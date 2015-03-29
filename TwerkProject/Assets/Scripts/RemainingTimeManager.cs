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

		// If the game is over
		if (countDownEndSeconds <= 0) {
			GameManager.Instance.EndGame ();
		}
		
		if (GameManager.Instance.matchStarted) {
			text.text = "Time Remaining: " + countDownEndSeconds;
		}
	}
}
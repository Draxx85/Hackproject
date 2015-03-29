using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartTimeManager : MonoBehaviour
{
	private Text text;
	private float deltaTime = 0.0f;
	private int countDownStartSeconds = 0;
	public int startCountdownTime = 4;
	
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
				text.text = "TWERK!";
			} else {
				text.text = (countDownStartSeconds - 1).ToString ();
			}
		} else {
			text.text = "";
		}
	}
}
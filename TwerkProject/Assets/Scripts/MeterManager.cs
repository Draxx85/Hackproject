using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MeterManager : MonoBehaviour
{
	public delegate void OnMeterFullEventHandler();
	public delegate void OnFreeResetEventHandler();

	private const int YellowThresholdPercent = 200;
	private const int RedThresholdPercent = 50;

	public static int fill;
	public static event OnMeterFullEventHandler MeterHasFilled;
	public static event OnFreeResetEventHandler FreeHasReset;

	private Slider slider;
	private float deltaTime = 0.0f;
	private int countDownStartSeconds = 0;
	private bool inFreeMode = false;

	public int startValue = 15;
	public Image fillImage;
	public int startCountdownTime = 6;
	
	void Awake ()
	{
		slider = GetComponent <Slider> ();
		MeterHasFilled += new OnMeterFullEventHandler(ResetMeter);
		FreeHasReset += new OnFreeResetEventHandler(ResetFree);
		fill = startValue;
		deltaTime = Time.time;
		countDownStartSeconds = startCountdownTime;
		inFreeMode = false;
	}
	
	void Update ()
	{
		// Change the remaining time
		if (Time.time - deltaTime >= 1.0f) {
			deltaTime = Time.time;
			
			if (GameManager.Instance.matchStarted && inFreeMode) {
				countDownStartSeconds--;
			}
		}
		
		// when free mode is over
		if (countDownStartSeconds <= 0) {
			if(FreeHasReset != null)
			{
				FreeHasReset();
			}
		}

		slider.value = fill;

		if (slider.value <= RedThresholdPercent) {
			fillImage.color = Color.red;
		} else if (slider.value <= YellowThresholdPercent) {
			fillImage.color = Color.yellow;
		} else {
			fillImage.color = Color.white;
		}

		if (slider.value >= slider.maxValue) {
			if(MeterHasFilled != null)
			{
				MeterHasFilled();
			}
		}
	}

	void ResetMeter(){
		fill = startValue;
		inFreeMode = true;
		Debug.Log ("Meter filled. Resetting the meter");
	}

	void ResetFree(){
		inFreeMode = false;
		countDownStartSeconds = startCountdownTime;
		Debug.Log ("Free mode over");
	}
}
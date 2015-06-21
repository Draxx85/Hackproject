/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* MeterManager.cs : Tracks the meters progress and when we reach free mode
*----------------------------------------------------------------
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MeterManager : MonoBehaviour {
	public delegate void OnMeterFullEventHandler ();

	public delegate void OnFreeResetEventHandler ();
	
	public static event OnMeterFullEventHandler MeterHasFilled;
	public static event OnFreeResetEventHandler FreeHasReset;
	
	private static readonly int YellowThresholdPercent = 200;
	private static readonly int RedThresholdPercent = 50;
	public static int fill;
	private Slider slider;
	private float deltaTime = 0.0f;
	private int countDownStartSeconds = 0;
	private bool inFreeMode = false;
	public int startValue = 15;
	public Image fillImage;
	public int startCountdownTime = 6;
	
	public void Awake () {
		slider = GetComponent <Slider> ();
		MeterHasFilled += new OnMeterFullEventHandler (ResetMeter);
		FreeHasReset += new OnFreeResetEventHandler (ResetFree);
		fill = startValue;
		deltaTime = Time.time;
		countDownStartSeconds = startCountdownTime;
		inFreeMode = false;
	}
	
	public void Update () {
		// Change the remaining time
		if (Time.time - deltaTime >= 1.0f) {
			deltaTime = Time.time;
			
			if (GameManager.Instance.matchStarted && inFreeMode) {
				countDownStartSeconds--;
			}
		}
		
		// When free mode is over
		if (countDownStartSeconds <= 0) {
			if (FreeHasReset != null) {
				FreeHasReset ();
			} else {
				Debug.LogWarning ("Failed to run FreeHasReset()");
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
			if (MeterHasFilled != null) {
				MeterHasFilled ();
			} else {
				Debug.LogWarning ("Failed to run MeterHasFilled()");
			}
		}
	}

	private void ResetMeter () {
		fill = startValue;
		inFreeMode = true;
		Debug.Log ("Meter filled. Free Mode entered. Resetting the meter.");
	}

	private void ResetFree () {
		inFreeMode = false;
		countDownStartSeconds = startCountdownTime;
		Debug.Log ("Free mode over");
	}
}
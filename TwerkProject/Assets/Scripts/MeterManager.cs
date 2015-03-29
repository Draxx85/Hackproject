using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MeterManager : MonoBehaviour
{
	public delegate void OnMeterFullEventHandler();

	private const int YellowThresholdPercent = 200;
	private const int RedThresholdPercent = 50;

	public static int fill;
	public static event OnMeterFullEventHandler MeterHasFilled;

	private Slider slider;

	public int startValue = 15;
	public Image fillImage;
	//public GameObject meterExplosion;
	
	void Awake ()
	{
		slider = GetComponent <Slider> ();
		MeterHasFilled += new OnMeterFullEventHandler(ResetMeter);
		fill = startValue;
	}
	
	void Update ()
	{
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
		//Instantiate(meterExplosion, slider.transform.position, slider.transform.rotation);
		Debug.Log ("Meter filled. Resetting the meter");
	}
}
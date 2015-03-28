using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MeterManager : MonoBehaviour
{
	private const int YellowThresholdPercent = 35;
	private const int RedThresholdPercent = 10;

	public static int fill;

	private Slider slider;

	public Image fillImage;
	
	void Awake ()
	{
		slider = GetComponent <Slider> ();
		fill = 0;
	}
	
	void Update ()
	{
		slider.value = fill;

		if (slider.value <= RedThresholdPercent) {
			fillImage.color = Color.red;
		} else if (slider.value <= YellowThresholdPercent) {
			fillImage.color = Color.yellow;
		} else {
			fillImage.color = Color.green;
		}
	}
}
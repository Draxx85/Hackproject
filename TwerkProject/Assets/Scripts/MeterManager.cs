using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MeterManager : MonoBehaviour
{
	public static int fill;

	Slider slider;
	
	void Awake ()
	{
		slider = GetComponent <Slider> ();
		fill = 0;
	}
	
	void Update ()
	{
		slider.value = fill;
	}
}
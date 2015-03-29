﻿using UnityEngine;
using System.Collections;

public class AnimatorManager : MonoBehaviour {

	public enum AnimationType
	{
		AnimationType_TRIGGER,
		AnimationType_BOOL,
		AnimationType_MAX
	};

	private Animator explosion;
	public AnimationType type = AnimationType.AnimationType_MAX;
	public string triggerName;

	// Use this for initialization
	void Start () {
		MeterManager.MeterHasFilled += new MeterManager.OnMeterFullEventHandler(StartAnimation);
		MeterManager.FreeHasReset += new MeterManager.OnFreeResetEventHandler(EndAnimation);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void StartAnimation(){
		explosion = GetComponent<Animator> ();

		if (type == AnimationType.AnimationType_TRIGGER) {
			Debug.Log("triggering trigger " + triggerName);
			explosion.SetTrigger (triggerName);
		} 
		if(type == AnimationType.AnimationType_BOOL) {
			Debug.Log("start bool " + triggerName);
			explosion.SetBool (triggerName, true);
		}
	}
	
	void EndAnimation(){
		explosion = GetComponent<Animator> ();

		if(type == AnimationType.AnimationType_BOOL) {
			Debug.Log("end bool " + triggerName);
			explosion.SetBool (triggerName, false);
		}
	}
}
/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* AnimatorManager.cs : Controls the initilazation of the animations
*----------------------------------------------------------------
*/
using UnityEngine;
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
			explosion.SetTrigger (triggerName);
		} 
		if(type == AnimationType.AnimationType_BOOL) {
			explosion.SetBool (triggerName, true);
		}
	}
	
	void EndAnimation(){
		explosion = GetComponent<Animator> ();

		if(type == AnimationType.AnimationType_BOOL) {
			explosion.SetBool (triggerName, false);
		}
	}
}

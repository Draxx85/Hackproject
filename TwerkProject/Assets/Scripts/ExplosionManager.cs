using UnityEngine;
using System.Collections;

public class ExplosionManager : MonoBehaviour {

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
		MeterManager.MeterHasFilled += new MeterManager.OnMeterFullEventHandler(DoAnimation);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void DoAnimation(){
		explosion = GetComponent<Animator> ();

		if (type == AnimationType.AnimationType_TRIGGER) {
			explosion.SetTrigger (triggerName);
		} 
		if(type == AnimationType.AnimationType_BOOL) {
			explosion.SetBool (triggerName, true);
		}
	}
}

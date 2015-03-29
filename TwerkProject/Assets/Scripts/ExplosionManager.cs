using UnityEngine;
using System.Collections;

public class ExplosionManager : MonoBehaviour {
	
	private Animator explosion;

	// Use this for initialization
	void Start () {
		MeterManager.MeterHasFilled += new MeterManager.OnMeterFullEventHandler(DoAnimation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DoAnimation(){
		explosion = GetComponent<Animator> ();
		explosion.SetTrigger ("fireballAnim");
	}
}

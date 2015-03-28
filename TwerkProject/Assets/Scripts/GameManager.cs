using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	// Singleton
	public static GameManager Instance {
		get {
			return instance;
		}
	}
	private static GameManager instance;
	void Awake( ) {
		if (instance == null) {
			instance = this;
		}
	}
	
	public int drainInterval = 3;
	public int drainAmount = 12;
	public bool hasNewScore = true;
	public int scoreDelta = 15;

	private float lastDrainTime = 0.0f;

	// Use this for initialization
    void Start()
	{
		ScoreManager.score = 1;
		lastDrainTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		// For manual update of the score and meter only
		if (hasNewScore) {
			UpdateScore(scoreDelta);
		}

		// Drain the meter over time
		if (Time.time - lastDrainTime > drainInterval) {
			lastDrainTime = Time.time;
			MeterManager.fill -= drainAmount;
		}

		hasNewScore = false;
	}

	public void UpdateScore(int delta){
		ScoreManager.score += delta;
		MeterManager.fill += delta;
	}
}

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
	public string sceneToLoad;
	public bool matchStarted;

	private float lastDrainTime = 0.0f;

	// Use this for initialization
    void Start()
	{
		ScoreManager.score = 1;
		lastDrainTime = Time.time;
		matchStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		// For manual update of the score and meter only
		if (hasNewScore) {
			UpdateScore(scoreDelta);
		}

		if (matchStarted) {
			// Drain the meter over time
			if (Time.time - lastDrainTime > drainInterval) {
				lastDrainTime = Time.time;
				MeterManager.fill -= drainAmount;
			}
		}

		hasNewScore = false;
	}

	public void UpdateScore(int delta){
		if (matchStarted) {
			ScoreManager.score += delta;
			MeterManager.fill += delta;
		}
	}
	
	public void StartGame(){
		matchStarted = true;
	}

	public void EndGame(){		
		matchStarted = false;

		if (!string.IsNullOrEmpty (sceneToLoad)) {
			print ("Load Scene: " + sceneToLoad);
			Application.LoadLevel (sceneToLoad);
		} else {
			print ("No scene to load");
		}
	}
}

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
	
	public bool hasNewScore = true;
	public int scoreDelta = 5;

	// Use this for initialization
    void Start()
	{
		ScoreManager.score = 1;
		MeterManager.fill = 10;
	}
	
	// Update is called once per frame
	void Update () {
		scoreDelta = 5;

		if (hasNewScore) {
			ScoreManager.score += scoreDelta;
			MeterManager.fill += scoreDelta;
		}

		hasNewScore = false;
	}

	public void UpdateScore(int delta){
		hasNewScore = true;
		scoreDelta = delta;
	}
}

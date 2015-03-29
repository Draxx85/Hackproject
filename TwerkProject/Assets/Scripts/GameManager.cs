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
	
	private float lastDrainTime = 0.0f;
	private float lastSpawnTime = 0.0f;
	
	private Vector3 startLocation = Vector3.zero;
	
	public int drainInterval = 3;
	public int drainAmount = 12;
	public bool hasNewScore = true;
	public int scoreDelta = 15;
	public string sceneToLoad;
	public bool matchStarted;

	public GameObject mainSymbol;

	// Use this for initialization
    void Start()
	{
		ScoreManager.score = 1;
		lastDrainTime = Time.time;
		matchStarted = false;

		//startLocation = mainSymbolStartLocation.transform.position;
		startLocation = new Vector3(954,683,0);
		//startLocation = mainSymbolStartLocation.transform.position;
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
			
			if (Time.time - lastSpawnTime > Symbol.fallSpeedStatic) {
				lastSpawnTime = Time.time;
				//Symbol.makeSymbol2(startLocation);
				makeSymbol3();
			}
		}

		hasNewScore = false;
	}

	public void UpdateScore(int delta){
		if (true) {
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
	
	public void makeSymbol3 ()
	{
		Vector3 spawnPosition = startLocation;
		Instantiate (mainSymbol, spawnPosition, Quaternion.identity);
	}
}

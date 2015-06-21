/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* GameManager.cs : Tracks the games progress, score, and etc
*----------------------------------------------------------------
*/
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	// Singleton
	public static GameManager Instance {
		get {
			return instance;
		}
	}
	private static GameManager instance;
	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
	}
	
	private float lastDrainTime = 0.0f;
	private float lastSpawnTime = 0.0f;
	public Vector3 startLocation = new Vector3 (954, 683, 0);

	public int drainInterval = 3;
	public int drainAmount = 12;
	public bool hasNewScore = true;
	public int scoreDelta = 15;
	public string sceneToLoad;
	public bool matchStarted;
	public float symbolFallSpeed = 0.0f;
	public GameObject mainSymbol;

	// Use this for initialization
	void Start ()
	{
		ScoreManager.score = 1;
		lastDrainTime = Time.time;
		matchStarted = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// For manual update of the score and meter only
		if (hasNewScore) {
			UpdateScore (scoreDelta);
		}

		if (matchStarted) {
			// Drain the meter over time
			if (Time.time - lastDrainTime > drainInterval) {
				lastDrainTime = Time.time;
				MeterManager.fill -= drainAmount;
			}
			
			if (Time.time - lastSpawnTime > symbolFallSpeed) {
				lastSpawnTime = Time.time;
				SpawnNewSymbol ();
			}
		}

		hasNewScore = false;
	}

	public void UpdateScore (int delta)
	{
		ScoreManager.score += delta;
		MeterManager.fill += delta;
	}
	
	public void StartGame ()
	{
		matchStarted = true;
	}

	public void EndGame ()
	{		
		matchStarted = false;

		if (!string.IsNullOrEmpty (sceneToLoad)) {
			Debug.Log ("Load Scene: " + sceneToLoad);
			Application.LoadLevel (sceneToLoad);
		} else {
			Debug.Log ("No scene to load");
		}
	}
	
	public void SpawnNewSymbol ()
	{
		Vector3 spawnPosition = startLocation;
		Instantiate (mainSymbol, spawnPosition, Quaternion.identity);
	}
}

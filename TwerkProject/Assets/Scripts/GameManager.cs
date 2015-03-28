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

	public Transform orbPrefab;
	public GUIText scorePrefab;
    public Transform currentOrb;
    public string sceneToLoad;
	private float scoreSpacing = 0.1f;
	private Dictionary<PlayerController, int> playerScores = new Dictionary<PlayerController,int>();
	private Dictionary<PlayerController, GUIText> scoreBoard = new Dictionary<PlayerController, GUIText>();
	public int winningScore = 5;

	public float minRotationInterval = 5;
	public float maxRotationInterval = 20;
	private float nextRotationTime;
    private int previousSpawnLocation = int.MaxValue;
    private GameObject[] orbSpawns;

	// Use this for initialization
    void Start()
    {
	}
	
	// Update is called once per frame
	void Update () {
		ScoreManager.score = 1;
//		GameObject.FindObjectsOfType<PlayerController>()
//		foreach (PlayerController playerController in playerScores.Keys) {
//			scoreBoard[playerController].text = playerController.tag + ": " + playerScores[playerController];
//		}

//        if (getCurrentWinner() != null || (Input.GetButton("Cancel") && !string.IsNullOrEmpty(sceneToLoad)))
//        {
//            foreach (PlayerController playerController in playerScores.Keys)
//            {
//                PlayerPrefs.SetInt(playerController.tag, playerScores[playerController]);
//            }
//
//            print("Load Scene: " + sceneToLoad);
//            Application.LoadLevel(sceneToLoad); 
//        }
	}

    public Dictionary<PlayerController, int> GetScores()
    {
        return playerScores;
    }

//	public void ReportScore(PlayerController playerController) {
//		if (playerScores.ContainsKey(playerController)) {
//			playerScores[playerController] += 1;
//		} else {
//			playerScores.Add(playerController, 1);
//			scoreBoard.Add(playerController, ((GameObject)GameObject.Instantiate(scorePrefab)).GetComponent<GUIText>());
//		}
//	}
//	public void ReportScore(PlayerController playerController, int points) {
//		if (playerScores.ContainsKey(playerController)) {
//			playerScores[playerController] += points;
//		} else {
//			playerScores.Add(playerController, points);
//			scoreBoard.Add(playerController, ((GameObject)GameObject.Instantiate(scorePrefab.gameObject, new Vector3(0.05f, 0.95f - scoreBoard.Count * scoreSpacing, 0), Quaternion.identity)).GetComponent<GUIText>());
//		}
//	}
}

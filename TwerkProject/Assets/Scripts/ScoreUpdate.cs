using UnityEngine;
using System.Collections;

public class ScoreUpdate : MonoBehaviour {

	public static int getMultiplier ( int streak) {
		if (streak < 10)
			return 1;
		else if (streak < 20)
			return 2;
		else if (streak < 30)
			return 3;
		else if (streak < 40)
			return 4;
		else
			return 5;
	}

	public  static void updateScore(int points, int streak) {
		int multiplier = getMultiplier (streak);
		int tempScore = ScoreManager.score;
		ScoreManager.score += points * multiplier;
		GameManager.Instance.UpdateScore (ScoreManager.score-tempScore);
	}
}
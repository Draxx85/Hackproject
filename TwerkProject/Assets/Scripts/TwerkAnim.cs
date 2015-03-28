using UnityEngine;
using System.Collections;

public class TwerkAnim : MonoBehaviour {

	/* TwerkAnim class will be used to determine which Twerk animation to perform
	 * -1 - Idle
	 *  1 - UP
	 *  2 - RIGHT
	 *  3 - DOWN
	 *  4 - LEFT
	 */
	
	int POOR_MIN_THRESHOLD = 10;
	int GREAT_MIN_THRESHOLD = 50;
	int AMAZING_MIN_THRESHOLD = 80;

	int missAnim = 1;

	int STREAK2x = 10;
	int STREAK3x = 20;	
	int STREAK4x = 30;
	int STREAK5x = 40;


	Animator animator;

	int transitionInt = 0;
	int streak = 0;
	float animTimer;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animTimer = 0;
		//this will be removed and determineAnimation will be called by Jeremy's function that finds the accuracy of a move
		InvokeRepeating("determineRandomAnimation", 0.0f, 4.0f);
	}

	void Update() {
		animTimer += Time.deltaTime;

		if (animTimer > 2.1f && transitionInt != 0) {
			transitionInt = 0;
			animator.SetInteger ("transitionInt", transitionInt);
		}
	}

	public void determineRandomAnimation(){
		determineAnimation (Random.Range (1, 100), Random.Range (1,4));
	}	

	public int getMultiplier ( int streak) {
		if (streak < STREAK2x)
			return 1;
		else if (streak < STREAK3x)
			return 2;
		else if (streak < STREAK4x)
			return 3;
		else if (streak < STREAK5x)
			return 4;
		else
			return 5;
	}

	public  int getDelta (int points, int streak) {
		return points * getMultiplier (streak);
	}
	
	public void determineAnimation(int score, int direction){
		if (score < POOR_MIN_THRESHOLD) {
			missAnim = -1;
			streak = 0;
		} else {
			missAnim = 1;
			streak++;
		}

		transitionInt = direction * missAnim;

		Debug.Log ("Transition: " + transitionInt.ToString (), gameObject);
		Debug.Log ("Streak: " + streak.ToString (), gameObject);
		animator.SetInteger ("transitionInt", transitionInt);
		animTimer = 0;
		
		GameManager.Instance.UpdateScore (getDelta(score, streak));
		Debug.Log ("Multiplier: " + getMultiplier(streak).ToString (), gameObject);
		Debug.Log ("Score: " + ScoreManager.score.ToString (), gameObject);
	}
}

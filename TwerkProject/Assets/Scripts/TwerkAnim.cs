using UnityEngine;
using System.Collections;

public class TwerkAnim : MonoBehaviour {

	/* TwerkAnim class will be used to determine which Twerk animation to perform
	 * -1 - Idle
	 *  1 - Miss
	 *  2 - Poor
	 *  3 - Great
	 *  4 - Perfect
	 */

	Animator animator;

	int transitionInt = -1;
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

		if (animTimer > 2.1f && transitionInt >= 0) {
			transitionInt = -1;
			animator.SetInteger ("transitionInt", transitionInt);
			Debug.Log ("Transition Reset: " + transitionInt.ToString (), gameObject);
			Debug.Log ("Transition Timer: " + animTimer.ToString (), gameObject);
		}
	}

	public void determineRandomAnimation(){
		transitionInt = Random.Range(1, 4);
		animTimer = 0;
		
		Debug.Log ("Transition: " + transitionInt.ToString (), gameObject);
		animator.SetInteger ("transitionInt", transitionInt);
	}	

	public void determineAnimation(int score){
		if (score < 10) {
			streak = 0;
			transitionInt = 1;
		} else if (score < 50) {
			streak++;
			transitionInt = 2;
		} else if (score < 80) {
			streak++;
			transitionInt = 3;
		} else {
			streak++;
			transitionInt = 4;
		}
		
		Debug.Log ("Transition: " + transitionInt.ToString (), gameObject);
		animator.SetInteger ("transitionInt", transitionInt);

		ScoreUpdate.updateScore (score, streak);
	}
}

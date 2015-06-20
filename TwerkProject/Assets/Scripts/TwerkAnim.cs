﻿/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* TwerkAnim.cs : Handles the animation of words to score
*----------------------------------------------------------------
*/
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
	
	public const int POOR_MIN_THRESHOLD = 10;
	public const int OKAY_MIN_THRESHOLD = 40;
	public const int GREAT_MIN_THRESHOLD = 60;
	public const int AMAZING_MIN_THRESHOLD = 80;

	private const int MISS= 1;
	private const int POOR= 2;
	private const int OKAY = 3;
	private const int GREAT= 4;
	private const int AMAZING = 5;
	
	private const int STREAK2x = 10;
	private const int STREAK3x = 20;	
	private const int STREAK4x = 30;
	private const int STREAK5x = 40;

	private int animationQuality = 0;
	private int missAnim = 1;
	private int multiplier = 1;

	private Animator animator;
	private Animator[] qualAnimator;

	private int transitionInt = 0;
	private int streak = 0;
	private float animTimer = 0.0f;
	
	// Singleton
	public static TwerkAnim Instance {
		get {
			return instance;
		}
	}
	private static TwerkAnim instance;
	void Awake( ) {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		qualAnimator = GetComponentsInChildren<Animator> ();
		animTimer = 0;
	}

	void Update() {
		animTimer += Time.deltaTime;

		if (animTimer > 2.1f && transitionInt != 0) {
			transitionInt = 0;
			animTimer = 0;
			animator.SetInteger ("transitionInt", transitionInt);
		}
	}

	public void determineRandomAnimation(){
		determineAnimation (Random.Range (1, 100), Random.Range (1,4));
	}	

	public void calculateMultiplier ( int streak) {
		if (streak < STREAK2x)		multiplier = 1;
		else if (streak < STREAK3x) multiplier = 2;
		else if (streak < STREAK4x) multiplier = 3;
		else if (streak < STREAK5x)	multiplier = 4;
		else						multiplier = 5;
	}

	public int getMultiplier () {
		return multiplier;
	}
	public  int getDelta (int points, int streak) {
		calculateMultiplier (streak);
		return points * multiplier;
	}

	void matchedInput (int quality)	{
		animationQuality = quality;
		missAnim = 1;
		streak++;
	}

	void missMatchedInput(){
		// End their multiplier streak and animation chain
		streak = 0;
		missAnim = -1;
		animationQuality = MISS;
	}
	
	public void determineAnimation(int score, int direction){
		if (score < POOR_MIN_THRESHOLD) {
			missMatchedInput();
		} else if (score < OKAY_MIN_THRESHOLD) {
			matchedInput (POOR);
		} else if (score < GREAT_MIN_THRESHOLD) {
			matchedInput (OKAY);
		} else if (score < AMAZING_MIN_THRESHOLD) {
			matchedInput (GREAT);
		} else {
			matchedInput (AMAZING);
		}

		transitionInt = direction * missAnim;

		animator.SetInteger ("transitionInt", transitionInt);
		qualAnimator[1].SetInteger ("qualityFlag", animationQuality);

		animTimer = 0;
		
		GameManager.Instance.UpdateScore (getDelta(score, streak));
	}
}

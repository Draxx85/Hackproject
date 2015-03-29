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
	int OKAY_MIN_THRESHOLD = 40;
	int GREAT_MIN_THRESHOLD = 60;
	int AMAZING_MIN_THRESHOLD = 80;

	private const int MISS= 1;
	private const int POOR= 2;
	private const int OKAY = 3;
	private const int GREAT= 4;
	private const int AMAZING = 5;

	private int animationQuality = 0;
	private int missAnim = 1;
	private int multiplier = 1;

	private int STREAK2x = 10;
	private int STREAK3x = 20;	
	private int STREAK4x = 30;
	private int STREAK5x = 40;


	Animator animator;
	Animator[] qualAnimator;


	int transitionInt = 0;
	int streak = 0;
	float animTimer;

	
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
		//Canvas.Instantiate ();
		//qualAnimator =  Canvas.GetComponent<Animator> ();
		animTimer = 0;
		//this will be removed and determineAnimation will be called by Jeremy's function that finds the accuracy of a move
		//InvokeRepeating("determineRandomAnimation", 0.0f, 4.0f);
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

	void nonMissInput (int quality)	{
		animationQuality = quality;
		missAnim = 1;
		streak++;
	}
	
	public void determineAnimation(int score, int direction){
		if (score < POOR_MIN_THRESHOLD) {
			animationQuality = MISS;
			missAnim = -1;
			streak = 0;
		} else if (score < OKAY_MIN_THRESHOLD) {
			nonMissInput (POOR);
		} else if (score < GREAT_MIN_THRESHOLD) {
			nonMissInput (OKAY);
		} else if (score < AMAZING_MIN_THRESHOLD) {
			nonMissInput (GREAT);
		} else {
			nonMissInput (AMAZING);
		}

		transitionInt = direction * missAnim;

		//Debug.Log ("Transition: " + transitionInt.ToString (), gameObject);
		//Debug.Log ("Move Score: " + score , gameObject);
		//Debug.Log ("Quality: " + animationQuality, gameObject);
		animator.SetInteger ("transitionInt", transitionInt);
		//qualAnimator[0].SetInteger ("qualityFlag", animationQuality);
		qualAnimator[1].SetInteger ("qualityFlag", animationQuality);
		//qualTrig.showQuality (animationQuality);

		animTimer = 0;
		
		GameManager.Instance.UpdateScore (getDelta(score, streak));
	}
}

using UnityEngine;
using System.Collections;

public class EvaluateMove : MonoBehaviour {

	const int targetRange = 100;
	const int validRange = 100;
	TwerkAnim  twerkAnim = new TwerkAnim();

	public static void userInputKey (int direction) {

		/*
		 * if direction == next symbol from the symbol manager
		 * 		determineScore(getNextSymbol().y,direction);
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 */

	}

	void determineScore(int height,int direction) {
		twerkAnim.determineAnimation (Mathf.Abs (height - targetRange), direction);
	}

	// Update is called once per frame
	void Update () {
	
	}
}

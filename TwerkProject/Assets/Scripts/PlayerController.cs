using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
	public static int UP_TRANSITION = 1;
	public static int RIGHT_TRANSITION = 2;
	public static int DOWN_TRANSITION = 3;
	public static int LEFT_TRANSITION = 4;
	public EvaluateMove evaluateMove = new EvaluateMove();

	void Update ()
	{
		if (Input.GetButtonDown ("Up")) {
			evaluateMove.userInputKey(UP_TRANSITION);
			Debug.Log ("UP was pressed", gameObject);
		}
		if (Input.GetButtonDown ("Right")) {
			evaluateMove.userInputKey(RIGHT_TRANSITION);
			Debug.Log ("RIGHT was pressed", gameObject);
		}
		if (Input.GetButtonDown ("Down")) {
			evaluateMove.userInputKey(DOWN_TRANSITION);
			Debug.Log ("DOWN was pressed", gameObject);
		}		
		if (Input.GetButtonDown ("Left")) {
			evaluateMove.userInputKey(LEFT_TRANSITION);
			Debug.Log ("LEFT was pressed", gameObject);
		}
	}
}

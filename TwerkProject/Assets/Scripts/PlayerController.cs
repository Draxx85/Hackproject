using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public static int UP_TRANSITION = 1;
	public static int RIGHT_TRANSITION = 2;
	public static int DOWN_TRANSITION = 3;
	public static int LEFT_TRANSITION = 4;

	void Update ()
	{
		if (Input.GetButtonDown ("Up")) {
			EvaluateMove.Instance.userInputKey(UP_TRANSITION);
			Debug.Log ("UP was pressed", gameObject);
		}
		if (Input.GetButtonDown ("Right")) {
			EvaluateMove.Instance.userInputKey(RIGHT_TRANSITION);
			Debug.Log ("RIGHT was pressed", gameObject);
		}
		if (Input.GetButtonDown ("Down")) {
			EvaluateMove.Instance.userInputKey(DOWN_TRANSITION);
			Debug.Log ("DOWN was pressed", gameObject);
		}		
		if (Input.GetButtonDown ("Left")) {
			EvaluateMove.Instance.userInputKey(LEFT_TRANSITION);
			Debug.Log ("LEFT was pressed", gameObject);
		}
	}
}

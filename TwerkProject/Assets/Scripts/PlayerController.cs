using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
	private const string SpritePath = "SpriteAnchor/Sprite";

	public static int UP_TRANSITION = 1;
	public static int RIGHT_TRANSITION = 2;
	public static int DOWN_TRANSITION = 3;
	public static int LEFT_TRANSITION = 4;

	void Update ()
	{
		Animator animator = this.GetComponentInChildren<Animator> ();
		if (Input.GetButtonDown ("Up")) {
			EvaluateMove.userInputKey(UP_TRANSITION);
			Debug.Log ("UP was pressed", gameObject);
		}
		if (Input.GetButtonDown ("Right")) {
			EvaluateMove.userInputKey(RIGHT_TRANSITION);
			Debug.Log ("RIGHT was pressed", gameObject);
			//Invoke ("returnToIdle", 2);
		}
		if (Input.GetButtonDown ("Down")) {
			EvaluateMove.userInputKey(DOWN_TRANSITION);
			Debug.Log ("DOWN was pressed", gameObject);
		}		
		if (Input.GetButtonDown ("Left")) {
			EvaluateMove.userInputKey(LEFT_TRANSITION);
			Debug.Log ("LEFT was pressed", gameObject);
		}
	}
}

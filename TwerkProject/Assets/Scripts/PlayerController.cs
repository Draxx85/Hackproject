using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
	private const string SpritePath = "SpriteAnchor/Sprite";

	void Update ()
	{
		Animator animator = this.GetComponentInChildren<Animator> ();
		if (Input.GetButton ("Up")) {
			animator.SetInteger ("transitionInt", 1);
			Debug.Log ("UP was pressed", gameObject);
			Invoke ("returnToIdle", 2);
			//animator.transform.localScale = new Vector3 (1, 1, 1);
		}
		if (Input.GetButton ("Right")) {
			animator.SetInteger ("transitionInt", 2);
			Debug.Log ("RIGHT was pressed", gameObject);
			Invoke ("returnToIdle", 2);
			//animator.transform.localScale = new Vector3 (1, 1, 1);
		}
		if (Input.GetButton ("Down")) {
			animator.SetInteger ("transitionInt", 3);
			Debug.Log ("DOWN was pressed", gameObject);
			Invoke ("returnToIdle", 2);
			//animator.transform.localScale = new Vector3 (1, 1, 1);
		}		
		if (Input.GetButton ("Left")) {
			animator.SetInteger ("transitionInt", 4);
			Debug.Log ("LEFT was pressed", gameObject);
			Invoke ("returnToIdle", 2);
			//animator.transform.localScale = new Vector3 (-1, 1, 1);
		}
	}

	void returnToIdle () {
		Animator animator = this.GetComponentInChildren<Animator> ();
		animator.SetInteger ("transitionInt", 0);
	}
}

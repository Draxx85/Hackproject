using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
	private const string SpritePath = "SpriteAnchor/Sprite";

	void Update ()
	{
		Animator animator = this.GetComponentInChildren<Animator> ();

		if (Input.GetButton ("Left")) {
			animator.SetBool ("Moving", true);
			animator.transform.localScale = new Vector3 (-1, 1, 1);
		}
		if (Input.GetButton ("Right")) {
			animator.SetBool ("Moving", true);
			animator.transform.localScale = new Vector3 (1, 1, 1);
		}
		if (!Input.GetButton ("Up")) {
			animator.SetBool ("Moving", true);
			animator.transform.localScale = new Vector3 (1, 1, 1);
		}
		if (Input.GetButton ("Down")) {
			animator.SetBool ("Moving", true);
			animator.transform.localScale = new Vector3 (1, 1, 1);
		}
	}
}

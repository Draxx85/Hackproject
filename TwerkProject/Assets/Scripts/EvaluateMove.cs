using UnityEngine;
using System.Collections;

public class EvaluateMove : MonoBehaviour
{

	// We should pull this targetRange from hitbox
	int targetRange = 120;

	bool isHeightSet = false;
	public GameObject HitBox;
	int validRange = 100;
	const int MAX_SCORE = 100;

	// Singleton
	public static EvaluateMove Instance {
		get {
			return instance;
		}
	}

	private static EvaluateMove instance;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
	}
	
	public void Start ()
	{
		targetRange = (int) HitBox.transform.position.y;
		Debug.Log ("target: " +targetRange);
		validRange = (int) (HitBox.transform.position.y - HitBox.transform.lossyScale.y/2);
		Debug.Log ("range: " +targetRange);
	}

	public void userInputKey (int direction)
	{
		if (SymbolManager.Instance.mainSymbolList.Count > 0) {
			GameObject otherSymbol = SymbolManager.Instance.mainSymbolList.Peek () as GameObject;

			if (!isHeightSet) {
				targetRange += (int) otherSymbol.transform.lossyScale.y/2;
				isHeightSet = true;
			}

			int symbolDirection = 0;

			SpriteRenderer otherRenderer = otherSymbol.GetComponent<SpriteRenderer> ();

			if (otherRenderer != null) {
				if (otherRenderer.sprite.name == "arrowUp") {
					symbolDirection = PlayerController.UP_TRANSITION;
				} else if (otherRenderer.sprite.name == "arrowRight") {
					symbolDirection = PlayerController.RIGHT_TRANSITION;
				} else if (otherRenderer.sprite.name == "arrowDown") {
					symbolDirection = PlayerController.DOWN_TRANSITION;
				} else if (otherRenderer.sprite.name == "arrowLeft") {
					symbolDirection = PlayerController.LEFT_TRANSITION;
				}
			
				//Debug.Log ("symbol direction: " + symbolDirection);
				//Debug.Log ("Score: " + Mathf.Abs ((int)otherSymbol.transform.position.y - targetRange));

				
				Debug.Log ("height: " +(int)otherSymbol.transform.position.y);
				if (direction == symbolDirection) {
					determineScore ((int)otherSymbol.transform.position.y, symbolDirection);
				} else {
					TwerkAnim.Instance.determineAnimation (0, symbolDirection);
				}

				GameObject temp = SymbolManager.Instance.mainSymbolList.Dequeue () as GameObject;
				if (temp != null) {
					Destroy (temp);
				}
			}
		}
	}

	void determineScore (int height, int direction)
	{
		TwerkAnim.Instance.determineAnimation (Mathf.Max (MAX_SCORE - (Mathf.Abs (height - targetRange)), 0), direction);
	}
}

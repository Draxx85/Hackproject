using UnityEngine;
using System.Collections;

public class EvaluateMove : MonoBehaviour {

	// We should pull this targetRange from hitbox
	const int targetRange = -160;
	const int validRange = 100;
	const int MAX_SCORE = 100;

	// Singleton
	public static EvaluateMove Instance {
		get {
			return instance;
		}
	}
	private static EvaluateMove instance;
	void Awake( ) {
		if (instance == null) {
			instance = this;
		}
	}
	
	public void Start() {
		//mySymbol = GetComponent<GameObject> ();
	}

	public void userInputKey (int direction) {
		GameObject otherSymbol = SymbolManager.Instance.mainSymbolList.Peek () as GameObject;

		int symbolDirection = 0;

		SpriteRenderer otherRenderer = otherSymbol.GetComponent<SpriteRenderer>();

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
			
			Debug.Log("symbol direction: " + symbolDirection);
			Debug.Log("Symbol Height: " + otherSymbol.transform.position.y);
			Debug.Log("Target Height: " + targetRange);
			Debug.Log("Score: " + Mathf.Abs ((int)otherSymbol.transform.position.y - targetRange));
			if (direction == symbolDirection) {
				determineScore ((int)otherSymbol.transform.position.y, symbolDirection);
			} else {
				TwerkAnim.Instance.determineAnimation (0, symbolDirection);
			}
			
		} 
	}

	static void determineScore(int height,int direction) {
		TwerkAnim.Instance.determineAnimation ( Mathf.Max(MAX_SCORE - (Mathf.Abs (height - targetRange)), 0), direction);
	}
}

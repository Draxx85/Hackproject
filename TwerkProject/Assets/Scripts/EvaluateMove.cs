using UnityEngine;
using System.Collections;

public class EvaluateMove : MonoBehaviour {

	const int targetRange = 100;
	const int validRange = 100;
	
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

		if (otherRenderer.sprite.name == "arrowUp"){
			symbolDirection = 1;
		}
		else if (otherRenderer.sprite.name == "arrowRight"){
			symbolDirection = 2;
		}
		else if (otherRenderer.sprite.name == "arrowDown"){
			symbolDirection = 3;
		}
		else if (otherRenderer.sprite.name == "arrowLeft"){
			symbolDirection = 4;
		}

		if (direction == symbolDirection) {
			determineScore ((int)otherSymbol.transform.position.y, symbolDirection);
		} else {
			TwerkAnim.Instance.determineAnimation (0, symbolDirection);
		}
	}

	static void determineScore(int height,int direction) {
		TwerkAnim.Instance.determineAnimation (Mathf.Abs (height - targetRange), direction);
	}
}

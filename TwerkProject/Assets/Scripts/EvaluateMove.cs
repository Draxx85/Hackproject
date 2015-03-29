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
	
	public GameObject mySymbol;
	public void Start() {
		//mySymbol = GetComponent<GameObject> ();
	}

	public void userInputKey (int direction) {
		GameObject otherSymbol = SymbolManager.Instance.symbolList.Peek () as GameObject;

		int symbolDirection = 0;

		SpriteRenderer otherRenderer = otherSymbol.GetComponent<SpriteRenderer>();
		SpriteRenderer myRenderer = mySymbol.GetComponent<SpriteRenderer> ();

		/*if (otherRenderer.sprite == Symbol.upSprite){
			symbolDirection = 1;
		}
		else if (otherRenderer.sprite == .rightSprite){
			symbolDirection = 2;
		}
		else if (otherRenderer.sprite == Symbol.downSprite){
			symbolDirection = 3;
		}
		else if (otherRenderer.sprite == (SymbolManager.Instance.symbolList.Peek () as Symbol).leftSprite){
			symbolDirection = 4;
		}*/
		if (otherRenderer.sprite == myRenderer.sprite) {

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

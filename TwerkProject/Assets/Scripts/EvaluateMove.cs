using UnityEngine;
using System.Collections;

public class EvaluateMove : MonoBehaviour {

	const int targetRange = 100;
	const int validRange = 100;
	TwerkAnim  twerkAnim = new TwerkAnim();
	Symbol symbol = new Symbol();
	int symbolDirection;

	public void userInputKey (int direction) {
		GameObject newSymbol = symbol.peek () as GameObject;

		SpriteRenderer myRenderer = newSymbol.GetComponent<SpriteRenderer>();
		if (myRenderer.sprite == symbol.upSprite){
			symbolDirection = 1;
		}
		else if (myRenderer.sprite == symbol.rightSprite){
			symbolDirection = 2;
		}
		else if (myRenderer.sprite == symbol.downSprite){
			symbolDirection = 3;
		}
		else if (myRenderer.sprite == symbol.leftSprite){
			symbolDirection = 4;
		}

		if (direction == symbolDirection) {
			determineScore ((int)newSymbol.transform.position.y, symbolDirection);
		} else {
			twerkAnim.determineAnimation (0, symbolDirection);
		}
	}

	void determineScore(int height,int direction) {
		twerkAnim.determineAnimation (Mathf.Abs (height - targetRange), direction);
	}

	// Update is called once per frame
	void Update () {
	
	}
}

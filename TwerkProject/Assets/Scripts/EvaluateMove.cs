/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* EvaluateMove.cs : Evaluates the players inputed move and determines the score generated from it
*----------------------------------------------------------------
*/
using UnityEngine;
using System.Collections;

public class EvaluateMove : MonoBehaviour {
	// Singleton
	public static EvaluateMove Instance {
		get {
			return instance;
		}
	}

	private static EvaluateMove instance;

	public void Awake () {
		if (instance == null) {
			instance = this;
		}
	}
	
	private bool isHeightSet = false;
	private bool inFreeMode = false;	// When the meter is filled we go into our special mode
	private int targetRange = 120;
	public GameObject HitBox;
	public int maxScore = 100;

	public void Start () {
		targetRange = (int)HitBox.transform.position.y;

		MeterManager.MeterHasFilled += new MeterManager.OnMeterFullEventHandler (EnterFreeMode);
		MeterManager.FreeHasReset += new MeterManager.OnFreeResetEventHandler (ExitFreeMode);

		inFreeMode = false;
	}

	public void userInputKey (int direction) {
		if (!inFreeMode) {
			if (SymbolManager.Instance.mainSymbolList.Count > 0) {
				GameObject otherSymbol = SymbolManager.Instance.mainSymbolList.Peek () as GameObject;
				SpriteRenderer otherRenderer = otherSymbol.GetComponent<SpriteRenderer> ();
				int symbolDirection = 0;

				// XXX: Can't remember what this was for
				// Set the distance height to the target location of the symbols at run time?
				if (!isHeightSet) {
					targetRange += (int)otherSymbol.transform.lossyScale.y / 2;
					isHeightSet = true;
				}

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

					Debug.Log ("symbol direction: " + symbolDirection);
					Debug.Log ("Score: " + Mathf.Abs ((int)otherSymbol.transform.position.y - targetRange));

					// If they hit the key the right direction then score
					// either way show the correct animation but missed key is automatic 'miss'
					if (direction == symbolDirection) {
						determineScore ((int)otherSymbol.transform.position.y, symbolDirection);
					} else {
						TwerkAnim.Instance.determineAnimation (0, symbolDirection);
					}

					// Since this symbol has been scored we can deque and remove if from the scene
					GameObject temp = SymbolManager.Instance.mainSymbolList.Dequeue () as GameObject;
					if (temp != null) {
						Destroy (temp);
					}
				}
			}
		} else {
			// Give constant score in free mode
			TwerkAnim.Instance.determineAnimation (TwerkAnim.AMAZING_MIN_THRESHOLD, direction);
		}
	}
	
	private void determineScore (int height, int direction) {
		TwerkAnim.Instance.determineAnimation (3 * Mathf.Max (maxScore - (Mathf.Abs (height - targetRange)), 0), direction);
	}

	private void EnterFreeMode () {
		inFreeMode = true;
	}
	
	private void ExitFreeMode () {
		inFreeMode = false;
	}
}

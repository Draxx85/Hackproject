using UnityEngine;
using System.Collections;

public class EvaluateMove : MonoBehaviour
{
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

	private const int MAX_SCORE = 100;
	
	private bool isHeightSet = false;
	private bool inFreeMode = false;
	private int targetRange = 120;

	public GameObject HitBox;

	public void Start ()
	{
		targetRange = (int)HitBox.transform.position.y;

		MeterManager.MeterHasFilled += new MeterManager.OnMeterFullEventHandler (EnterFreeMode);
		MeterManager.FreeHasReset += new MeterManager.OnFreeResetEventHandler (ExitFreeMode);

		inFreeMode = false;
	}

	public void userInputKey (int direction)
	{
		if (!inFreeMode) {
			if (SymbolManager.Instance.mainSymbolList.Count > 0) {
				GameObject otherSymbol = SymbolManager.Instance.mainSymbolList.Peek () as GameObject;

				if (!isHeightSet) {
					targetRange += (int)otherSymbol.transform.lossyScale.y / 2;
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
					Debug.Log ("symbol direction: " + symbolDirection);
					Debug.Log ("Score: " + Mathf.Abs ((int)otherSymbol.transform.position.y - targetRange));

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
		} else {
			// Give constant score in free mode
			TwerkAnim.Instance.determineAnimation (TwerkAnim.AMAZING_MIN_THRESHOLD, direction);
		}
	}
	
	private void determineScore (int height, int direction)
	{
		TwerkAnim.Instance.determineAnimation (3 * Mathf.Max (MAX_SCORE - (Mathf.Abs (height - targetRange)), 0), direction);
	}

	private void EnterFreeMode ()
	{
		inFreeMode = true;
	}
	
	private void ExitFreeMode ()
	{
		inFreeMode = false;
	}
}

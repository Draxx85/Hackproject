using UnityEngine;
using System.Collections;

public class Symbol : MonoBehaviour {
	//public GameObject MainSymbol;

	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float fallSpeed;

	private Sprite currentSymbol;
	private SpriteRenderer myRenderer;
	public Sprite leftSprite;
	public Sprite rightSprite;
	public Sprite upSprite;
	public Sprite downSprite;
	
	public int direction = 0;

	public static float fallSpeedStatic = 0.0f;
	private static GameObject MainSymbolStatic;

	void Start() {
		if (MainSymbolStatic == null) {
			MainSymbolStatic = gameObject;
			fallSpeedStatic = fallSpeed;
		}
		//StartCoroutine (makeSymbol ());
		//myRenderer = MainSymbol.GetComponent<SpriteRenderer>();
		myRenderer = gameObject.GetComponent<SpriteRenderer>();

		switch(Random.Range (0,4) )
		{
		case 0:
			myRenderer.sprite = leftSprite;
			direction = 4;
			break;
		case 1:
			myRenderer.sprite = rightSprite;
			direction = 2;
			break;
		case 2:
			myRenderer.sprite = upSprite;
			direction = 1;
			break;
		case 3:
			myRenderer.sprite = downSprite;
			direction = 3;
			break;
		}

		SymbolManager.Instance.mainSymbolList.Enqueue (gameObject);
		//Debug.Log (SymbolManager.Instance.mainSymbolList.Count);
	}
	
	IEnumerator makeSymbol ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			//Vector3 spawnPosition = startLocation;
			//Instantiate (MainSymbol, spawnPosition, Quaternion.identity);

//			if(SymbolManager.Instance.mainSymbolList.Count > 10){
//				GameObject temp = SymbolManager.Instance.mainSymbolList.Dequeue () as GameObject;
//				Destroy (temp, 1);
//			}

			yield return new WaitForSeconds (spawnWait);
		}
	}
	
	
	public static void makeSymbol2 (Vector3 startLocation)
	{
		Vector3 spawnPosition = startLocation;
		Instantiate (MainSymbolStatic, spawnPosition, Quaternion.identity);
	}

	void Update() {
		transform.Translate(spawnValues.x, spawnValues.y - fallSpeed, spawnValues.z);
	}
}
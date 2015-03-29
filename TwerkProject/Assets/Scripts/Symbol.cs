using UnityEngine;
using System.Collections;

public class Symbol : MonoBehaviour {
	public GameObject MainSymbol;

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
	
	// Singleton
	public static Symbol Instance {
		get {
			return instance;
		}
	}
	private static Symbol instance;
	void Awake( ) {
		if (instance == null) {
			instance = this;
		}
	}

	void Start() {
		StartCoroutine (makeSymbol ());
		myRenderer = MainSymbol.GetComponent<SpriteRenderer>();

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

		SymbolManager.Instance.symbolList.Enqueue (MainSymbol);
		Debug.Log (SymbolManager.Instance.symbolList.Count);
	}
	
	IEnumerator makeSymbol ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			Vector3 spawnPosition = new Vector3 (9.1f, 7, 0);
			Instantiate (MainSymbol, spawnPosition, Quaternion.identity);

			if(SymbolManager.Instance.symbolList.Count > 10){
				SymbolManager.Instance.symbolList.Dequeue ();
				//GameObject temp = SymbolManager.Instance.symbolList.Dequeue () as GameObject;
				//Destroy (gameObject, lifetime);
			}

			yield return new WaitForSeconds (spawnWait);
		}
	}

	void Update() {
		transform.Translate(spawnValues.x, spawnValues.y - fallSpeed, spawnValues.z);
	}

	public GameObject peek (){
		return SymbolManager.Instance.symbolList.Peek () as GameObject;
	}
}
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
	private static Vector3 startLocation = Vector3.zero;
	
	public int direction = 0;

	void Start() {
		if (startLocation == Vector3.zero) {
			startLocation = MainSymbol.transform.position;
		}
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

		SymbolManager.Instance.mainSymbolList.Enqueue (MainSymbol);
		Debug.Log (SymbolManager.Instance.mainSymbolList.Count);
	}
	
	IEnumerator makeSymbol ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			//Vector3 spawnPosition = new Vector3 (9.1f, 7, 0);
			Vector3 spawnPosition = startLocation;
			Instantiate (MainSymbol, spawnPosition, Quaternion.identity);

			if(SymbolManager.Instance.mainSymbolList.Count > 10){
				//SymbolManager.Instance.mainSymbolList.Dequeue ();
				GameObject temp = SymbolManager.Instance.mainSymbolList.Dequeue () as GameObject;
				Destroy (temp, 1);
			}

			yield return new WaitForSeconds (spawnWait);
		}
	}

	void Update() {
		transform.Translate(spawnValues.x, spawnValues.y - fallSpeed, spawnValues.z);
	}

	public GameObject peek (){
		return SymbolManager.Instance.mainSymbolList.Peek () as GameObject;
	}
}
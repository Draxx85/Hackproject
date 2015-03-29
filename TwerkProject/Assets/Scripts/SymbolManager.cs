using UnityEngine;
using System.Collections;

public class SymbolManager : MonoBehaviour {
	public GameObject Symbol;

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

	public int actuState = 3;

	void Start() {
		StartCoroutine (makeSymbol ());
		myRenderer = Symbol.GetComponent<SpriteRenderer>();

		switch(Random.Range (0,4) )
		{
		case 0:
			myRenderer.sprite = leftSprite;
			break;
		case 1:
			myRenderer.sprite = rightSprite;
			break;
		case 2:
			myRenderer.sprite = upSprite;
			break;
		case 3:
			myRenderer.sprite = downSprite;
			break;
		}
	}
	
	IEnumerator makeSymbol ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			Vector3 spawnPosition = new Vector3 (7, 7, 0);
			Instantiate (Symbol, spawnPosition, Quaternion.identity);
			yield return new WaitForSeconds (spawnWait);
		}
	}

	void Update() {
		transform.Translate(spawnValues.x, spawnValues.y - fallSpeed, spawnValues.z);
		
	}
}
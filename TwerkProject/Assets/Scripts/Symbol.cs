using UnityEngine;
using System.Collections;

public class Symbol : MonoBehaviour {

	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float fallSpeed;

	private SpriteRenderer myRenderer;
	public Sprite leftSprite;
	public Sprite rightSprite;
	public Sprite upSprite;
	public Sprite downSprite;
	
	public int direction = 0;

	void Start() {
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
	}

	void Update() {
		transform.Translate(spawnValues.x, spawnValues.y - fallSpeed, spawnValues.z);
	}
}
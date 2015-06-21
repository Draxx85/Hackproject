/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* Symbol.cs : Handles the creation for the falling symbols
*----------------------------------------------------------------
*/
using UnityEngine;
using System.Collections;

public class Symbol : MonoBehaviour {
	
	private SpriteRenderer myRenderer;
	public Vector3 spawnValues;
	public float fallSpeed;
	public Sprite leftSprite;
	public Sprite rightSprite;
	public Sprite upSprite;
	public Sprite downSprite;
	public int direction = 0;

	public void Start () {
		myRenderer = gameObject.GetComponent<SpriteRenderer> ();

		switch (Random.Range (0, 4)) {
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

	public void Update () {
		transform.Translate (spawnValues.x, spawnValues.y - fallSpeed, spawnValues.z);
	}
}
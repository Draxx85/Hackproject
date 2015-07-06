using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimpleSpriteToggleTimer : MonoBehaviour {
	
	private float lastToggleTime = 0.0f;

	public float timeInterval = 3.0f;
	public Sprite spriteA;
	public Sprite spriteB;

	// Use this for initialization
	void Start () {
		
		lastToggleTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time - lastToggleTime > timeInterval) {
			lastToggleTime = Time.time;
			Image currentSprite = gameObject.GetComponent<Image> ();
			if(currentSprite.sprite.name == spriteA.name){
				currentSprite.sprite = spriteB;
			}else{
				currentSprite.sprite = spriteA;
			}
		}
	}
}

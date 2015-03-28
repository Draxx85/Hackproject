using UnityEngine;
using System.Collections;

public class TwerkAnim : MonoBehaviour {

	/* TwerkAnim class will be used to determine which Twerk animation to perform
	 * 1 - Miss
	 * 2 - Poor
	 * 3 - Great
	 * 4 - Perfect
	 */

	Animator animator;
	
	float animTime = 0.0f;
	int transitionInt = -1;

// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		InvokeRepeating("determineAnimation", 0.0f, 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		animTime += Time.deltaTime;

		if (animTime > 1.1f)
			animTime = 0; 
	}

	public void determineAnimation(){
		transitionInt = Random.Range(1, 4);
		animTime = 0;

		Debug.Log ("Transition: " + transitionInt.ToString (), gameObject);
		animator.SetInteger ("transitionInt", transitionInt);
	}
}

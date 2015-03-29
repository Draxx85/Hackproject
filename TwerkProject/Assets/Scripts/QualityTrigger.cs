using UnityEngine;
using System.Collections;

public class QualityTrigger : MonoBehaviour {
	Animator animator;

	void Start() {
		animator = GetComponent<Animator> ();
	}

	public void showQuality(int quality) {
		animator.SetInteger ("qualityFlag", quality);
	}
}

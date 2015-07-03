using UnityEngine;
using System.Collections;

public class TransitionOnClick : MonoBehaviour {

	public void TranstitionTo (string sceneToLoad) {
		Debug.Log ("TransitionOnClick");

		if (!string.IsNullOrEmpty (sceneToLoad)) {
			Debug.Log ("Load Scene: " + sceneToLoad);
			Application.LoadLevel (sceneToLoad);
		} else {
			Debug.LogWarning ("No scene to load");
		}
	}
}

using UnityEngine;
using System.Collections;

public class SymbolManager : MonoBehaviour {
	public GameObject Symbol;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float fallSpeed;

	void Start() {
		StartCoroutine (makeSymbol ());
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
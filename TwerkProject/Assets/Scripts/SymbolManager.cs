using UnityEngine;
using System.Collections;

public class SymbolManager : MonoBehaviour {
	public GameObject symbol;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float fallSpeed;

	void Update() {

		transform.Translate(spawnValues.x, spawnValues.y - fallSpeed, spawnValues.z);

	}
}
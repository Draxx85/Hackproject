using UnityEngine;
using System.Collections;

public class SymbolManager : MonoBehaviour {
	public GameObject symbol;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;

	void Start ()
	{
		DropSymbol();
	}
	
	IEnumerator DropSymbol ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
			//Instantiate (symbol, spawnPosition);
			yield return new WaitForSeconds (spawnWait);
		}
	}
}
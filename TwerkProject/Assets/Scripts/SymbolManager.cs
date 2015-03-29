using UnityEngine;
using System.Collections;

public class SymbolManager : MonoBehaviour {
	public GameObject MainSymbol;
	public GameObject UpSymbol;
	public GameObject DownSymbol;
	public GameObject LeftSymbol;
	public GameObject RightSymbol;

	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float fallSpeed;
	
	void Start() {
		UpSymbol.SetActive (false);
		DownSymbol.SetActive (false);
		LeftSymbol.SetActive (false);
		RightSymbol.SetActive (false);

		switch (Random.Range(0,4))
		{
		case 0:
			UpSymbol.SetActive (true);
			break;
		case 1:
			DownSymbol.SetActive (true);
			break;
		case 2:
			LeftSymbol.SetActive (true);
			break;
		case 3:
			RightSymbol.SetActive (true);
			break;
		default:
			Debug.Log ("Shouldn't reach here.");
			break;
		}
		
		StartCoroutine (makeSymbol ());
	}

	IEnumerator makeSymbol ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			Vector3 spawnPosition = new Vector3 (-423, -211, 0);
			Instantiate (MainSymbol, spawnPosition, Quaternion.identity);
			yield return new WaitForSeconds (spawnWait);
		}
	}

	void Update() {
		transform.Translate(spawnValues.x, spawnValues.y - fallSpeed, spawnValues.z);
	}
}
using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour
{
	void Start ()
	{
	}

	void Update ()
	{
		if (SymbolManager.Instance.mainSymbolList.Count > 0) {
			if (gameObject.transform.position.y < 0) {

				GameObject temp = SymbolManager.Instance.mainSymbolList.Dequeue () as GameObject;			
				if (temp != null) {
					Destroy (temp);
				}
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour 
{
	void Start ()
	{
	}

	void Update()
	{
		if (gameObject.transform.position.y < 0) {
			Debug.Log ("deque object " + gameObject.name);
			GameObject temp = SymbolManager.Instance.mainSymbolList.Dequeue () as GameObject;
			Debug.Log ("destroy object " + temp.name);
			if(gameObject.name.CompareTo(temp.name) != 0)
			{
				Debug.Log ("WTF!");
			}
			Destroy (gameObject);
		}
	}
}

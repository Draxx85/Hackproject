using UnityEngine;
using System.Collections;

public class GarbageCollection : MonoBehaviour {

	public float lifetime;
	Symbol symbol = new Symbol();
	
	void Start ()
	{
		Destroy (gameObject, lifetime);
		symbol.dequeue ();
	}
}
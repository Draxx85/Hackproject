using UnityEngine;
using System.Collections;

public class GarbageCollection : MonoBehaviour {

	public float lifetime;
	
	void Start ()
	{
		Destroy (gameObject, lifetime);
	}
}

using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
	void OnTriggerExit (Collider other) 
	{
		Debug.Log ("destroying object " + other.gameObject.name);
		Destroy(other.gameObject);
	}
}

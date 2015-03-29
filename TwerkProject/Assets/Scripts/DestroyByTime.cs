using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour 
{
	public int destroyTime;

	void Start () 
	{
		Destroy (gameObject, destroyTime);
	}
}

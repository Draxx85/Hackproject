/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* DestroyOnExit.cs : Destroys objects as the leave out of the scene
*----------------------------------------------------------------
*/
using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour {

	public void Start () {

	}

	public void Update () {
		// If there are more floating symbols then we iterate through them
		if (SymbolManager.Instance.mainSymbolList.Count > 0) {

			// If this object has past boundaries
			if (gameObject.transform.position.y < 0) {

				// Make sure we deque if from our queue then we can destroy it
				GameObject temp = SymbolManager.Instance.mainSymbolList.Dequeue () as GameObject;			
				if (temp != null) {
					Destroy (temp);
				}
			}
		}
	}
}

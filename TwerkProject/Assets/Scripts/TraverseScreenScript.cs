/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* TraverseScreenScript.cs : Gets you from scene to scene
*----------------------------------------------------------------
*/
using UnityEngine;
using System.Collections;

public class TraverseScreenScript : MonoBehaviour {

    public string sceneToLoad;

    void OnGUI()
    {
        if (GUI.Button(new Rect(500, 450, 200, 50), "Click Here or Press Start"))
		{
			if (!string.IsNullOrEmpty (sceneToLoad)) {
				Debug.Log ("Load Scene: " + sceneToLoad);
				Application.LoadLevel (sceneToLoad);
			} else {
				Debug.LogWarning ("No scene to load");
			}
        }
    }

    void Start()
    {
		Debug.Log("Current Scene: " + Application.loadedLevelName);
    }

    void Update()
    {
        if (Input.GetButton("Submit"))
		{
			if (!string.IsNullOrEmpty (sceneToLoad)) {
				Debug.Log ("Load Scene: " + sceneToLoad);
				Application.LoadLevel (sceneToLoad);
			} else {
				Debug.LogWarning ("No scene to load");
			}
        }
    }
}

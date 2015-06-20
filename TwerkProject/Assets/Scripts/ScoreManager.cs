/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* ScoreManager.cs : Keeps track and renders the total score
*----------------------------------------------------------------
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public static int score;

	private Text text;

	public string scoreText = "Score:";
	
	void Awake ()
	{
		text = GetComponent <Text> ();
		score = 0;
	}
	
	void Update ()
	{
		text.text = scoreText + " " + score;
	}
}
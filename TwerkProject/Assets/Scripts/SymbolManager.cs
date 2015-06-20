/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Jeremy Bader 

*----------------------------------------------------------------
* SymbolManager.cs : Manages the object life of the symbols
*----------------------------------------------------------------
*/
using UnityEngine;
using System.Collections;

public class SymbolManager : MonoBehaviour {
	public Queue mainSymbolList = new Queue();
	
	// Singleton
	public static SymbolManager Instance {
		get {
			return instance;
		}
	}
	private static SymbolManager instance;
	void Awake( ) {
		if (instance == null) {
			instance = this;
		}
	}

	void Start(){
		mainSymbolList = Queue.Synchronized( mainSymbolList );
	}
}

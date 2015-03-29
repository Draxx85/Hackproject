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
}

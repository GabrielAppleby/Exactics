using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitScript : MonoBehaviour {
	protected Dictionary<string, int> stats;

	public void Init(Dictionary<string, int> stats) {
		this.stats = stats;
	}

	public virtual void Init() {
		this.stats = new Dictionary<string, int> ();
	}

}

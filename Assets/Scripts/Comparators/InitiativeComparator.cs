using UnityEngine;
using System.Collections.Generic;

public class InitiativeComparator : Comparer<GameObject> {


	public override int Compare(GameObject one, GameObject two)
	{
		int oneInit = one.GetComponent<InitiativeComponent> ().initiative;
		int twoInit = two.GetComponent<InitiativeComponent> ().initiative;
		if (oneInit < twoInit) {
			return -1;
		} else if (oneInit > twoInit) {
			return 1;
		} else {
			return 1;
		}
	}
}

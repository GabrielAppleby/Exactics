/*using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	


	void OnEnable()
	{
		UnitSetup.unitsReady += haveTurn;
	}
	void OnDisable()
	{
		UnitSetup.unitsReady -= haveTurn;
	}

	private void haveTurn(GameObject unit) {
		currentUnitChanged (unit);
	}
}
*/
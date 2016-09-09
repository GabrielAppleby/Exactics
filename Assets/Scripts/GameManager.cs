/*using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public delegate void CurrentUnitChanged(GameObject unit);
	public static event CurrentUnitChanged currentUnitChanged;


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
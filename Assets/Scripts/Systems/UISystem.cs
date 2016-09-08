using UnityEngine;
using System.Collections.Generic;


//
public class UISystem : MonoBehaviour {

	void OnEnable()
	{
		InputSystem.highlightMove += highlightMove;
		InputSystem.updateMenu += updateMenu;
	}


	void OnDisable()
	{
		InputSystem.highlightMove -= highlightMove;
		InputSystem.updateMenu -= updateMenu;
	}

	public void highlightMove(GameObject entity) {
		foreach(KeyValuePair<GameObject, GameObject> entry in entity.GetComponent<Movement>().camefrom)
		{
			Debug.Log (entry.Value.GetComponent<Transform> ().position);
		}
		//highlight grid
	}

	public void updateMenu(GameObject entity) {
		//Bring up menu
	}
}

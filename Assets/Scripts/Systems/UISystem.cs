using UnityEngine;


//
public class UISystem : MonoBehaviour {

	void OnEnable()
	{
		InputSystem.highlightMovement += highlightMovement;
		InputSystem.bringUpMenu += bringUpMenu;
	}


	void OnDisable()
	{
		InputSystem.highlightMovement -= highlightMovement;
		InputSystem.bringUpMenu -= bringUpMenu;
	}

	public void highlightMovement(GameObject entity, int movement) {
		//highlight grid
	}

	public void bringUpMenu(GameObject entity) {
		//Bring up menu
	}
}

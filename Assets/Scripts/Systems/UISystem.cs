using UnityEngine;


//
public class UISystem : MonoBehaviour
{
	void Start()
	{
		makeMenu ();
	}

	void OnEnable()
	{
		InputSystem.highlightMovement += highlightMovement;
		InputSystem.updateMenu += updateMenu;
	}


	void OnDisable()
	{
		InputSystem.highlightMovement -= highlightMovement;
		InputSystem.updateMenu -= updateMenu;
	}

	public void highlightMovement(GameObject entity, int movement)
	{
		//highlight grid
	}

	public void updateMenu(GameObject entity)
	{
		//Bring up menu
	}

	public void makeMenu()
	{
		//Bring up menu
	}

}

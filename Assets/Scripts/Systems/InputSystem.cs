using UnityEngine;
using System.Collections;


//I think in the future this class will be helpful
//For abstracting inputs into intentions
//For now its mostly just annoying
public class InputSystem : MonoBehaviour {

	public delegate void HighlightMovement(GameObject e, int speed);
	public static event HighlightMovement highlightMovement;

	public delegate void BringUpMenu(GameObject e);
	public static event BringUpMenu bringUpMenu;

	void OnEnable()
	{
		Input.onClick += directClick;
		Input.onHover += directHover;
	}


	void OnDisable()
	{
		Input.onClick -= directClick;
		Input.onHover -= directHover;
	}

	void directClick(GameObject entity) {
		bringUpMenu (entity);
	}

	void directHover(GameObject entity) {
		//Will depend on what components attached



		Movement movementComponent = entity.GetComponent<Movement> ();
		if (movementComponent != null) {
			//Should inputsystem pass the speed? From design point of view no
			//But it seems silly to do another getcomponent at next method..
			//We shall see
			highlightMovement (entity, movementComponent.movement);
		}
	}
}

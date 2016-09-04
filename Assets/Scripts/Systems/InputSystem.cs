using UnityEngine;
using System.Collections;


//I think in the future this class will be helpful
//For abstracting inputs into intentions
//For now its mostly just annoying
public class InputSystem : MonoBehaviour {

	public delegate void HighlightMovement(GameObject e, int speed);
	public static event HighlightMovement highlight;

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
		//Make a menu
	}

	void directHover(GameObject entity) {
		//Will depend on what components attached
		Movement movementComponent = entity.GetComponent<Movement> ();
		if (movementComponent != null) {
			//Lets go!
		}
	}
}

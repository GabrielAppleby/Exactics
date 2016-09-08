using UnityEngine;


//I think in the future this class will be helpful
//For abstracting inputs into intentions
//For now its mostly just annoying
public class InputSystem : MonoBehaviour {
	public enum States {Rest, Menu, Move};
	private States state = States.Rest;
	private GameObject selectedEntity;
	//when in move state click on tile triggers mvoe entity
	//So put state here?


	public delegate void MakeMove(GameObject entityToMove, GameObject entityWithLocation);
	public static event MakeMove makeMove;

	public delegate void CalculateMove(GameObject entity);
	public static event CalculateMove calculateMove;

	public delegate void HighlightMove(GameObject entity);
	public static event HighlightMove highlightMove;


	public delegate void UpdateMenu(GameObject e);
	public static event UpdateMenu updateMenu;

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
		selectedEntity = entity;
		switch (state) 
		{
		case States.Rest:
			state = States.Menu;
			updateMenu (entity);
			break;
		case States.Menu:
			//States = States.Rest;
			break;
		case States.Move:
			makeMove (selectedEntity, entity);
			break;
		default:
			break;
		}
	}

	void directHover(GameObject entity) {
		//Will depend on what components attached
		Movement movementComponent = entity.GetComponent<Movement> ();
		if (movementComponent != null) {
			selectedEntity = entity;
			calculateMove (entity);
			highlightMove (entity);
		}
	}
}

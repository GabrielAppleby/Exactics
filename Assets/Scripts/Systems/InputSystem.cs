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
		Input.onMouseEnter += directHover;
		UnitSetup.unitsReady += currentUnitChanged;
	}


	void OnDisable()
	{
		Input.onClick -= directClick;
		Input.onMouseEnter -= directHover;
		UnitSetup.unitsReady += currentUnitChanged;
	}

	void directClick(GameObject entity) {
		/*switch (state) 
		{
		case States.Rest:
			state = States.Menu;
			if (updateMenu != null) {
				updateMenu (entity);
			}
			break;
		case States.Menu:
			//States = States.Rest;
			break;
		case States.Move:
			if (makeMove != null) {
				makeMove (selectedEntity, entity);
			}
			break;
		default:
			break;
		}*/

		if (state == States.Move) {
			makeMove (selectedEntity, entity);
		}
	}

	public void clickedMove() {
		state = States.Move;
	}

	void clickedAttack() {

	}

	void directHover(GameObject entity) {
		//Will depend on what components attached
		Movement movementComponent = entity.GetComponent<Movement> ();
		if (movementComponent != null) {
			if (calculateMove != null) {
				calculateMove (entity);
			}
			if (highlightMove != null) {
				highlightMove (entity);
			}
		}
	}

	void currentUnitChanged(GameObject entity) {
		selectedEntity = entity;
	}

}

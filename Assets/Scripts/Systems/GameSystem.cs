using UnityEngine;


//I think in the future this class will be helpful
//For abstracting inputs into intentions
//For now its mostly just annoying
using System.Collections.Generic;


public class GameSystem : MonoBehaviour {
	public enum States {Rest, StopPressingButtonsWhileThingsAreHappeningTopaz, Move, Attack, Attacked};
	public States state = States.StopPressingButtonsWhileThingsAreHappeningTopaz;

	private int currentUnit;
	private GameObject selectedEntity;
	private List<GameObject> units;

	public delegate void BeginGame();
	public static event BeginGame gameStartRequested;

	public delegate void MoveRequested(GameObject entityToMove, GameObject entityWithLocation);
	public static event MoveRequested moveRequested;

	public delegate void RestRequested(GameObject entity);
	public static event RestRequested restRequested;

	public delegate void AttackRequested(GameObject attacking, GameObject defending);
	public static event AttackRequested attackRequested;

	public delegate void MovementCalculationRequested(GameObject entity);
	public static event MovementCalculationRequested movementCalculationRequested;

	public delegate void MovementHighlightRequested(GameObject entity);
	public static event MovementHighlightRequested movementHighlightRequested;

	public delegate void EntityInfoUpdateRequested(GameObject e);
	public static event EntityInfoUpdateRequested entityInfoUpdateRequested;


	private void OnEnable()
	{
		InputComponent.onClick += directClick;
		//InputComponent.onMouseEnter += directHover;
		UnitSetup.unitsReady += startTheGame;
		UISystem.moveButtonClicked += handleMoveButtonClicked;
		UISystem.attackButtonClicked += handleAttackButtonClicked;
		UISystem.restButtonClicked += handleRestButtonClicked;
		MovementSystem.movementFinished += handleMovementFinished;
		CombatSystem.attackFinished += handleAttackFinished;
	}

	private void OnDisable()
	{
		InputComponent.onClick -= directClick;
		//InputComponent.onMouseEnter -= directHover;
		UnitSetup.unitsReady -= startTheGame;
		UISystem.moveButtonClicked -= handleMoveButtonClicked;
		UISystem.attackButtonClicked -= handleAttackButtonClicked;
		UISystem.restButtonClicked -= handleRestButtonClicked;
		CombatSystem.attackFinished -= handleAttackFinished;
	}

	private void startTheGame(List<GameObject> units) {
		this.units = units;
		currentUnit = 0;
		state = States.Rest;
		if (gameStartRequested != null) {
			gameStartRequested ();
		}
	}

	private void directClick(GameObject entity) {
		switch (state) {
		case States.Move:
			state = States.StopPressingButtonsWhileThingsAreHappeningTopaz;
			if (moveRequested != null) {
				moveRequested (units [currentUnit], entity);
			}
			break;
		case States.Attack:
			state = States.StopPressingButtonsWhileThingsAreHappeningTopaz;
			if (attackRequested != null) {
				attackRequested (units [currentUnit], entity);
			}
			break;
		case States.Attacked:
			break;
		case States.Rest:
			break;
		case States.StopPressingButtonsWhileThingsAreHappeningTopaz:
			break;
		default:
			Debug.Log ("Something went wrong with States (GameSystem Line 83)");
			break;
		}
	}

	private void directHover(GameObject entity) {
		//Will depend on what components attached
		MovementComponent movementComponent = entity.GetComponent<MovementComponent> ();
		if (movementComponent != null) {
			if (movementCalculationRequested != null) {
				movementCalculationRequested (entity);
			}
			if (movementHighlightRequested != null) {
				movementHighlightRequested (entity);
			}
		}
	}

	private void currentTurn(GameObject entity) {
		MovementComponent movementComponent = entity.GetComponent <MovementComponent> ();
		movementComponent.currentTile.GetComponent <SpriteRenderer> ().color = Color.cyan;
	}

	private void handleMoveButtonClicked() {
		switch (state) {
		case States.Move:
			break;
		case States.Attack:
			break;
		case States.Attacked:
			break;
		case States.StopPressingButtonsWhileThingsAreHappeningTopaz:
			break;
		case States.Rest:
			state = States.Move;
			break;
		default:
			Debug.Log ("Something went wrong with States (GameSystem Line 112)");
			break;
		}
	}

	private void handleAttackButtonClicked() {
		switch (state) {
		case States.Move:
			state = States.Attack;
			break;
		case States.Attack:
			break;
		case States.Attacked:
			break;
		case States.StopPressingButtonsWhileThingsAreHappeningTopaz:
			break;
		case States.Rest:
			state = States.Attack;
			break;
		default:
			Debug.Log ("Something went wrong with States (GameSystem Line 130)");
			break;
		}
	}

	private void handleMovementFinished ()
	{
		state = States.Move;
	}

	private void handleAttackFinished(bool success) {
		if (success == true) {
			state = States.Attacked;
		}
	}

	private void handleRestButtonClicked() {
		if (state != States.StopPressingButtonsWhileThingsAreHappeningTopaz) {
			state = States.Rest;
			if (restRequested != null) {
				restRequested (units[currentUnit]);
			}
			currentUnit = (currentUnit + 1) % units.Count;
		}
	}




	private void changeSelectedEntity(GameObject entity) {
		//Grab the first entity by initiative
		selectedEntity = entity;
		currentTurn(entity);
	}
		
		

}

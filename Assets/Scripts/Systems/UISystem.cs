using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class UISystem : MonoBehaviour {
	private GameObject canvas;


	public delegate void MoveButtonClicked();
	public static event MoveButtonClicked moveButtonClicked;

	public delegate void AttackButtonClicked();
	public static event AttackButtonClicked attackButtonClicked;

	public delegate void ActionButtonClicked();
	public static event ActionButtonClicked actionButtonClicked;

	public delegate void DelayButtonClicked();
	public static event DelayButtonClicked delayButtonClicked;

	public delegate void RestButtonClicked();
	public static event RestButtonClicked restButtonClicked;



	private void Awake()
	{
		canvas = GameObject.Find ("Canvas");
		canvas.SetActive (false);
		Button button;
		//Only one child
		foreach (Transform child in canvas.GetComponent<Transform>().GetChild(0)) {
			button = child.GetComponent<Button> ();
			switch (child.name) {
			case "moveBtn":
				button.onClick.AddListener (handleMoveButtonClicked);
				break;
			case "attackBtn":
				button.onClick.AddListener (handleAttackButtonClicked);
				break;
			case "actionBtn":
				button.onClick.AddListener (handleActionButtonClicked);
				break;
			case "delayBtn":
				button.onClick.AddListener (handleDelayButtonClicked);
				break;
			case "restBtn":
				button.onClick.AddListener (handleRestButtonClicked);
				break;
			default:
				Debug.Log ("Problem with buttons (UISystem line 26)");
				break;
			}
		}
	}


	void OnEnable()
	{
		GameSystem.gameStartRequested += beginGame;
		GameSystem.movementHighlightRequested += highlightMove;
		GameSystem.entityInfoUpdateRequested += updateMenu;

	}


	void OnDisable()
	{
		GameSystem.gameStartRequested -= beginGame;
		GameSystem.movementHighlightRequested -= highlightMove;
		GameSystem.entityInfoUpdateRequested -= updateMenu;
	}

	private void handleMoveButtonClicked() {
		if (moveButtonClicked != null) {
			moveButtonClicked ();
		}
	}
	private void handleAttackButtonClicked() {
		if (attackButtonClicked != null) {
			attackButtonClicked ();
		}
	}
	private void handleActionButtonClicked() {
		if (actionButtonClicked != null) {
			actionButtonClicked ();
		}
	}
	private void handleDelayButtonClicked() {
		if (delayButtonClicked != null) {
			delayButtonClicked ();
		}
	}
	private void handleRestButtonClicked() {
		if (restButtonClicked != null) {
			restButtonClicked ();
		}
	}

	public void highlightMove(GameObject entity) {
		foreach(KeyValuePair<GameObject, GameObject> entry in entity.GetComponent<MovementComponent>().camefrom)
		{	

		}
	}

	public void updateMenu(GameObject entity) {
		//updateMenu
	}

	private void beginGame() {
		canvas.SetActive (true);
	}
}

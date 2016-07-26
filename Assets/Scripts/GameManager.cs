using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private GameManager gameManagerInstance;
	private BoardManager boardManagerInstance;
	private LevelLoader levelLoaderInstance;



	//First thing that happens
	//Happens even if component not enabled
	private void Awake () {
		//Gets the board manager.
		gameManagerInstance = this;
		boardManagerInstance = gameObject.GetComponent<BoardManager> ();
		levelLoaderInstance = gameObject.GetComponent<LevelLoader> ();
		levelLoaderInstance.init ();
	}

	//Happens after awake, before first update.
	//Does not happen if component not enabled
	private void Start () {
		//Sets up the scene
		//The scene is safe!

	}
}

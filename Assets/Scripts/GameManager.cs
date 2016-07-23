using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 

public class GameManager : MonoBehaviour {

	private GameManager gameManagerInstance;
	private BoardManager boardManagerInstance; 

	//First thing that happens
	//Happens even if component not enabled
	private void Awake () {
		//Gets the board manager.
		gameManagerInstance = this;
		boardManagerInstance = GetComponent<BoardManager> ();
	}

	//Happens after awake, before first update.
	//Does not happen if component not enabled
	private void Start () {
		//Sets up the scene
		//The scene is safe!
		boardManagerInstance.SetupScene();
	}
		
}

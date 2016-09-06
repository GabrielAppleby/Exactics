using UnityEngine;
using UnityEditor;
using System.Collections;



//All of this will be rewritten once we have "tiled" maps

public class BoardCreation : MonoBehaviour {
	GameObject map;

	//Happens after awake, before first update.
	//Does not happen if component not enabled
	private void Start () {
		createMap ();
	}

	private void createMap() {

		map = (GameObject) Instantiate(Resources.Load("DebugMap"), new Vector3(-246, 213.5f, 0), Quaternion.identity);
	}




		
}
	
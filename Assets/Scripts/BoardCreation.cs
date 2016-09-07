using UnityEngine;
using UnityEditor;
using System.Collections;





public class BoardCreation : MonoBehaviour {
	//I will need this eventually
	//And I hate seeing the stupid
	//Unused variable warning..
	#pragma warning disable 0414
	GameObject map;
	#pragma warning restore 0414

	//Happens after awake, before first update.
	//Does not happen if component not enabled
	private void Start () {
		createMap ();
	}

	private void createMap() {

		map = (GameObject) Instantiate(Resources.Load<GameObject>("DebugMap"), new Vector3(-246, 213.5f, 0), Quaternion.identity);
	}




		
}
	
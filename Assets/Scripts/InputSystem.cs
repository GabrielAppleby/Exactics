using UnityEngine;
using System.Collections;

public class InputSystem : MonoBehaviour {

	void OnEnable()
	{
		Input.onClick += tellTiles;
	}


	void OnDisable()
	{
		Input.onClick -= tellTiles;
	}

	void tellTiles(GameObject e) {
		Debug.Log (e);
	}
}

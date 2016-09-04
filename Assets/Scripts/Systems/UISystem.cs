using UnityEngine;
using System.Collections;


//
public class UISystem : MonoBehaviour {

	void OnEnable()
	{
		//InputSystem.highlight += 
		//InputSystem.bringUpMenu += 
	}


	void OnDisable()
	{
		//InputSystem.highlight 
		//InputSystem.bringUpMenu 
	}

	public void highlightMovable(GameObject entity, int speed) {
		//highlight grid
		//This should attach somethign that makes a grid piece highlight..
		//But where should the method for figuring out where to highlight exist? Maybe attach
		//a reference to the current tile to the entity? then work from that?
		//Maybe it should talk to the movement system?
	}

	public void bringUpMenu() {
		//Bring up menu
	}
}

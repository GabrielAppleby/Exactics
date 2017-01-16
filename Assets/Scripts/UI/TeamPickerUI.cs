using UnityEngine;
using System.Collections;
using Entitas;

public sealed class TeamPickerUI : MonoBehaviour {

	Context _context;

	public void Start() {
		_context = Contexts.sharedInstance.game;
	}


	public void HandleBackButtonClick() {
		_context.CreateEntity().AddScene("MainMenu");
	}

}

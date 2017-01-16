using UnityEngine;
using System.Collections;
using Entitas;

public sealed class MainMenuUI : MonoBehaviour {
	
	Context _context;

	public void Start() {
		_context = Contexts.sharedInstance.game;
	}
		

	public void HandleFightButtonClick() {
		_context.CreateEntity().AddScene("TeamPicker");
	}

	public void HandleTeamBuilderButtonClick() {
		_context.CreateEntity().AddScene("TeamCreationPicker");
	}

	public void HandleOptionsButtonClick() {
		_context.CreateEntity().AddScene("Options");
	}

	public void HandleQuitButtonClick() {
		//_pool.CreateEntity().AddScene("Quit");
	}
}

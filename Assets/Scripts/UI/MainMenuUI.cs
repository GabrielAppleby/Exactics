using UnityEngine;
using System.Collections;
using Entitas;

public sealed class MainMenuUI : MonoBehaviour {
	
	GameContext _gameContext;

	public void Start() {
		_gameContext = Contexts.sharedInstance.game;
	}
		

	public void HandleFightButtonClick() {
		_gameContext.CreateEntity().AddScene("TeamPicker");
	}

	public void HandleTeamBuilderButtonClick() {
		_gameContext.CreateEntity().AddScene("TeamCreationPicker");
	}

	public void HandleOptionsButtonClick() {
		_gameContext.CreateEntity().AddScene("Options");
	}

	public void HandleQuitButtonClick() {
		//_pool.CreateEntity().AddScene("Quit");
	}
}

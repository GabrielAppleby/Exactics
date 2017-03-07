using UnityEngine;
using System.Collections;
using Entitas;

public sealed class MainMenuUI : MonoBehaviour {
	
	GameContext _gameContext;

	public void Start() {
		_gameContext = Contexts.sharedInstance.game;
	}
		

	public void HandleFightButtonClick() {
		_gameContext.ReplaceScene("TeamPicker");
	}

	public void HandleTeamBuilderButtonClick() {
		_gameContext.ReplaceScene("TeamCreationPicker");
	}

	public void HandleOptionsButtonClick() {
		_gameContext.ReplaceScene("Options");
	}

	public void HandleQuitButtonClick() {
		//_pool.CreateEntity().AddScene("Quit");
	}
}

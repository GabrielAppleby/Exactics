using UnityEngine;
using System.Collections;
using Entitas;

public sealed class OptionsUI : MonoBehaviour {

	GameContext _gameContext;

	public void Start() {
		_gameContext = Contexts.sharedInstance.game;
	}


	public void HandleBackButtonClick() {
		_gameContext.ReplaceScene("MainMenu");
	}
		
}

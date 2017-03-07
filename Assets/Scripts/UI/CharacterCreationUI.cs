using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class CharacterCreationUI : MonoBehaviour {
	
	GameContext _gameContext;
	public Text label;

	public void Start() {
		_gameContext = Contexts.sharedInstance.game;
	}
		

	public void HandleBackButtonClick() {
		_gameContext.ReplaceScene("TeamCreation");
	}


	public void HandleContinueButtonClick() {
		//add the character stuff.
	
	}

}
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
		_gameContext.CreateEntity().AddScene("TeamCreation");
	}


	public void HandleContinueButtonClick() {
		//add the character stuff.
	
	}

}
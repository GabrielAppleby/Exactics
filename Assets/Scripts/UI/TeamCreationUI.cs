using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class TeamCreationUI : MonoBehaviour {

	GameContext _gameContext;

	public Text _teamName;

	public void Start() {
		_gameContext = Contexts.sharedInstance.game;
	}

	public void HandleCharacterButtonClick() {
		_gameContext.CreateEntity().AddScene("CharacterCreation");
	}

	public void HandleBackButtonClick() {
		_gameContext.CreateEntity().AddScene("TeamCreationPicker");
	}


	public void HandleSaveButtonClick() {
		//
	}

}

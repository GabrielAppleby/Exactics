using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class TeamCreationUI : MonoBehaviour {

	Context _context;
	public Text _teamName;

	public void Start() {
		_context = Contexts.sharedInstance.game;
	}

	public void HandleCharacterButtonClick() {
		_context.CreateEntity().AddScene("CharacterCreation");
	}

	public void HandleBackButtonClick() {
		_context.CreateEntity().AddScene("TeamCreationPicker");
	}


	public void HandleSaveButtonClick() {
		//
	}

}

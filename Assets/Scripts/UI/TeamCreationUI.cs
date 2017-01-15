using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class TeamCreationUI : MonoBehaviour {

	Context _pool;
	public Text label;

	public void Start() {
		_pool = Contexts.sharedInstance.menu;
	}

	public void HandleCharacterButtonClick() {
		_pool.CreateEntity().AddScene("CharacterCreation");
	}

	public void HandleBackButtonClick() {
		_pool.CreateEntity().AddScene("TeamCreationPicker");
	}


	public void HandleSaveButtonClick() {
		//
	}

}

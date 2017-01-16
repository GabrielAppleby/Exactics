using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class TeamCreationUI : MonoBehaviour {

	Pool _pool;
	public Text label;

	public void Start() {
		_pool = Pools.sharedInstance.menu;
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

using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class CharacterCreationUI : MonoBehaviour {

	Context _pool;
	public Text label;

	public void Start() {
		_pool = Contexts.sharedInstance.menu;
	}
		

	public void HandleBackButtonClick() {
		_pool.CreateEntity().AddScene("TeamCreation");
	}


	public void HandleContinueButtonClick() {

		//
	}

}

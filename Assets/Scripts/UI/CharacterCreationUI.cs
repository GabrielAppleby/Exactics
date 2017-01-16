using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class CharacterCreationUI : MonoBehaviour {

	Pool _pool;
	public Text label;

	public void Start() {
		_pool = Pools.sharedInstance.menu;
	}
		

	public void HandleBackButtonClick() {
		_pool.CreateEntity().AddScene("TeamCreation");
	}


	public void HandleContinueButtonClick() {

		//
	}

}

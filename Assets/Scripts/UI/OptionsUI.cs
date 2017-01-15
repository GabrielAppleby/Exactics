using UnityEngine;
using System.Collections;
using Entitas;

public sealed class OptionsUI : MonoBehaviour {

	Context _pool;

	public void Start() {
		_pool = Contexts.sharedInstance.menu;
	}


	public void HandleBackButtonClick() {
		_pool.CreateEntity().AddScene("MainMenu");
	}
		
}

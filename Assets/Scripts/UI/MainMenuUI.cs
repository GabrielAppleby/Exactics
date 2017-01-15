using UnityEngine;
using System.Collections;
using Entitas;

public sealed class MainMenuUI : MonoBehaviour {
	
	Context _pool;

	public void Start() {
		_pool = Contexts.sharedInstance.menu;
	}
		

	public void HandleFightButtonClick() {
		_pool.CreateEntity().AddScene("TeamPicker");
	}

	public void HandleTeamBuilderButtonClick() {
		_pool.CreateEntity().AddScene("TeamCreationPicker");
	}

	public void HandleOptionsButtonClick() {
		_pool.CreateEntity().AddScene("Options");
	}

	public void HandleQuitButtonClick() {
		//_pool.CreateEntity().AddScene("Quit");
	}
}

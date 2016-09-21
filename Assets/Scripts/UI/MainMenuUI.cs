using UnityEngine;
using System.Collections;
using Entitas;

public sealed class MainMenuUI : MonoBehaviour {
	
	Pool _pool;

	public void Start() {
		_pool = Pools.sharedInstance.scene;
	}
		

	public void HandleFightButtonClick() {
		
		Debug.Log (_pool);
		_pool.CreateEntity().AddScene("TeamPicker");
	}

	public void HandleTeamBuilderButtonClick() {
		_pool.CreateEntity().AddScene("TeamCreation");
	}

	public void HandleOptionsButtonClick() {
		_pool.CreateEntity().AddScene("Options");
	}

	public void HandleQuitButtonClick() {
		//_pool.CreateEntity().AddScene("Quit");
	}
}

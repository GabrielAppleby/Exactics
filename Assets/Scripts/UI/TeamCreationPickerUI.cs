using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class TeamCreationPickerUI : MonoBehaviour {

	Pool _pool;
	public Text label;

	public void Start() {
		_pool = Pools.sharedInstance.scene;
	}


	public void HandleBackButtonClick() {
		_pool.CreateEntity().AddScene("MainMenu");
	}

	public void HandleTeamButtonClick() {
		_pool.CreateEntity().AddScene("TeamCreation");
	}

}

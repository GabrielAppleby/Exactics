using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class TeamCreationUI : MonoBehaviour {

	Pool _pool;
	public Text label;

	public void Start() {
		_pool = Pools.sharedInstance.scene;
	}


	public void HandleBackButtonClick() {
		_pool.CreateEntity().AddScene("MainMenu");
	}

	public void HandleTeamButtonClick(int team) {
		label.text = "Team: " + team;
	}

}

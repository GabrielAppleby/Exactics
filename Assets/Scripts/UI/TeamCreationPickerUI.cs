using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class TeamCreationPickerUI : MonoBehaviour, ITeamLoadedListener {

	GameContext _gameContext;
	string _name;

	public void Start() {
		_name = this.name;
		_gameContext = Contexts.sharedInstance.game;
		_gameContext.CreateEntity ()
			.AddTeamLoadedListener (this);
	}


//	REDO ME LATER
//  AFTER PROTOTYPE UI WILL BE GENERATED
//  IN A SYSTEM AND THIS PROBLEM WON'T EXIST
	public void TeamLoaded(Entity entity) {
		
	}

	public void HandleBackButtonClick() {
		_gameContext.ReplaceScene("MainMenu");
	}

	public void HandleTeamButtonClick() {
		GameEntity gameEntity = _gameContext.CreateEntity();
		gameEntity.AddName(_name);
		gameEntity.AddTeamCharacters (new string[5]);
		_gameContext.ReplaceScene("TeamCreation");
	}

}

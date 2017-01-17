using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class TeamCreationPickerUI : MonoBehaviour, ITeamLoadedListener {

	Context _context;
	string _name;

	public void Start() {
		_name = this.name;
		_context = Contexts.sharedInstance.game;
		_context.CreateEntity ()
			.AddTeamLoadedListener (this);
	}


//	REDO ME LATER
//  AFTER PROTOTYPE UI WILL BE GENERATED
//  IN A SYSTEM AND THIS PROBLEM WON'T EXIST
	public void TeamLoaded(Entity entity) {
		
	}

	public void HandleBackButtonClick() {
		_context.CreateEntity().AddScene("MainMenu");
	}

	public void HandleTeamButtonClick() {
		_context.CreateEntity ().AddName (_name).AddTeamCharacters(new string[5]);
		_context.CreateEntity().AddScene("TeamCreation");
	}

}

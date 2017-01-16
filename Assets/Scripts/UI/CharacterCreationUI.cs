using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class CharacterCreationUI : MonoBehaviour {
	
	Context _context;
	public Text label;

	public void Start() {
		_context = Contexts.sharedInstance.game;
	}
		

	public void HandleBackButtonClick() {
		_context.CreateEntity().AddScene("TeamCreation");
	}


	public void HandleContinueButtonClick() {

	
	}

}
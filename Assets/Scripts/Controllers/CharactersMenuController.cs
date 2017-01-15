using Entitas;
using UnityEngine;

public class CharactersMenuController : MenuController {

	Systems createSystems(Contexts Contexts) {
		return base.createSystems (Contexts);
			//.Add(Contexts.menu.CreateSystem (new TeamCreationSystem ())); Gabe made me do it
	}
}
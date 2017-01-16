using Entitas;
using UnityEngine;

public class CharactersMenuController : MenuController {

	Systems createSystems(Contexts contexts) {
		return base.createSystems (contexts)
			.Add(new TeamCreationSystem (contexts));
	}
}
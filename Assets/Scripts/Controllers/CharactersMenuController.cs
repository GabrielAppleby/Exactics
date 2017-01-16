using Entitas;
using UnityEngine;

public class CharactersMenuController : MenuController {

	Systems createSystems(Pools pools) {
		return base.createSystems (pools)
			.Add(pools.menu.CreateSystem (new TeamCreationSystem ()));
	}
}
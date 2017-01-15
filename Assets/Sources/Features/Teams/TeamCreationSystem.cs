using Entitas;
using System;

public sealed class TeamCreationSystem : IInitializeSystem {

	Context _pool;

	public void SetPool(Context Context) {
		_pool = Context;
	}

	public void Initialize() {
		//For loop up to 5 - number of team entities
		//create new teams
		//_pool.CreateEntity ()
			//.AddTeamCreation (Guid.NewGuid ().ToString (), "None");
	}
}
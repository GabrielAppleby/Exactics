using Entitas;
using System;

public sealed class TeamCreationSystem : ISetPool, IInitializeSystem {

	Pool _pool;

	public void SetPool(Pool pool) {
		_pool = pool;
	}

	public void Initialize() {
		//For loop up to 5 - number of team entities
		//create new teams
		//_pool.CreateEntity ()
			//.AddTeamCreation (Guid.NewGuid ().ToString (), "None");
	}
}
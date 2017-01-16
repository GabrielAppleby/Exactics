using Entitas;
using System;

public sealed class TeamCreationSystem : IInitializeSystem {

	public TeamCreationSystem(Contexts contexts) {}

	public void Initialize() {
		//For loop up to 5 - number of team entities
		//create new teams
		//_pool.CreateEntity ()
			//.AddTeamCreation (Guid.NewGuid ().ToString (), "None");
	}
}
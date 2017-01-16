using Entitas;

public sealed class UnitCreationSystem : IInitializeSystem {

	Context _context;
	//Group _group;

	public UnitCreationSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		//_group = _pool.GetGroup(Matcher.AnyOf (CoreMatcher.Selected, CoreMatcher.TeamCreation));
		//TeamComponent currentTeam = _group.GetSingleEntity ().team;
		//_pool.CreateEntity ()
			//.IsInteractive (true)
			//.IsSelected (true)
			//.AddTeam(currentTeam.guid, currentTeam.name);
	}

	/*
	public void Execute() {

	}*/
	//Temporary for testing purposes
	//This sort of stuff will live in start in the future
	//Don't move them in now as then it would be possible for place units to
	//try to reference an uninitialized array
	/*public void Initialize() {
		Entity unit;
		for (int i = 0; i < 6; i++) {
			unit = _pool.CreateEntity ()
				.AddFakePosition(0,0)
				.AddPosition(0,0)
				.IsInteractive(true);
			changeJob (tempUnit, Constants.Jobs.Arcanist);
			changeRace (tempUnit, Constants.Races.Avian);
			tempUnit.GetComponent<FakeTransformComponent>().position = tiles[i].GetComponent<FakeTransformComponent>().position;
			tempUnit.GetComponent<Transform> ().position = tiles[i].GetComponent<Transform>().position;
			moveComponent = tempUnit.GetComponent<MovementComponent> ();
			moveComponent.waterWalk = false;
			moveComponent.stoneWalk = false;
			moveComponent.dirtWalk = true;
			moveComponent.currentTile = tiles [i];
			tiles [i].GetComponent<TerrainInfoComponent> ().unit = tempUnit;

			if (i > 2) {
				tempUnit.GetComponent<TeamComponent> ().team = Constants.Team.Red;
				tempUnit.GetComponent<SpriteRenderer> ().color = Color.red;
			} else {
				tempUnit.GetComponent<TeamComponent> ().team = Constants.Team.Blue;
			}

			units.Add (tempUnit);
		}
		//units.Sort (new InitiativeComparator ());
	}

	//Change jobs and update stats
	public void changeJob(GameObject entity, Constants.Jobs job) 
	{
		Dictionary<Constants.Stats, int> stats;
		Constants.jobStats.TryGetValue (job, out stats);
		updateStats (entity, stats);
	}

	//Change races and update stats
	public void changeRace(GameObject entity, Constants.Races race)
	{
		Dictionary<Constants.Stats, int> stats;
		Constants.raceStats.TryGetValue (race, out stats);
		updateStats (entity, stats);
	}

	//Update stats
	private void updateStats(GameObject entity, Dictionary<Constants.Stats, int> stats)
	{
		DefenseComponent defense = entity.GetComponent<DefenseComponent> ();
		InitiativeComponent initiative = entity.GetComponent<InitiativeComponent> ();
		ManaComponent mana = entity.GetComponent<ManaComponent> ();
		MovementComponent movement = entity.GetComponent<MovementComponent> ();
		OffenseComponent offense = entity.GetComponent<OffenseComponent> ();
		StaminaComponent stamina = entity.GetComponent<StaminaComponent> ();

		stats.TryGetValue (Constants.Stats.Health, out defense.health);
		defense.currentHealth = defense.health;
		stats.TryGetValue (Constants.Stats.Stamina, out stamina.stamina);
		stats.TryGetValue (Constants.Stats.Mana, out mana.mana);
		stats.TryGetValue (Constants.Stats.Movement, out movement.movement);
		movement.currentMovement = movement.movement;
		stats.TryGetValue (Constants.Stats.Spellpower, out offense.spellpower);
		stats.TryGetValue (Constants.Stats.Damage, out offense.damage);
		stats.TryGetValue (Constants.Stats.Accuracy, out offense.accuracy);
		stats.TryGetValue (Constants.Stats.Defense, out defense.defense);
		stats.TryGetValue (Constants.Stats.Evasion, out defense.evasion);
		stats.TryGetValue (Constants.Stats.Fortitude, out defense.fortitude);
		stats.TryGetValue (Constants.Stats.Resistance, out defense.resistance);
		stats.TryGetValue (Constants.Stats.Initiative, out initiative.initiative);
	}*/

}
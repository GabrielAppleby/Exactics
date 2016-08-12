using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitCreationManager : MonoBehaviour {

	//listens on events to create characters
	Dictionary<string, GameObject> characters;
	ObjectFactory objectFactory;
	GameObject unit;

	// Use this for initialization
	private void Start () {
		characters = new Dictionary<string, GameObject>();
		objectFactory = new ObjectFactory ();
		unit = objectFactory.createUnit ();
	}


	public void changeJob(Constants.Classes job) {
		Job oldJob = unit.GetComponent<Job> ();
		Dictionary<Constants.Stats, int> stats;
		Constants.classStats.TryGetValue (job, out stats);

		stats.TryGetValue (Constants.Stats.Health, out oldJob.health);
		stats.TryGetValue (Constants.Stats.Stamina, out oldJob.stamina);
		stats.TryGetValue (Constants.Stats.Mana, out oldJob.mana);
		stats.TryGetValue (Constants.Stats.Speed, out oldJob.speed);
		stats.TryGetValue (Constants.Stats.Spellpower, out oldJob.spellpower);
		stats.TryGetValue (Constants.Stats.Damage, out oldJob.damage);
		stats.TryGetValue (Constants.Stats.Accuracy, out oldJob.accuracy);
		stats.TryGetValue (Constants.Stats.Defense, out oldJob.defense);
		stats.TryGetValue (Constants.Stats.Evasion, out oldJob.evasion);
		stats.TryGetValue (Constants.Stats.Fortitude, out oldJob.fortitude);
		stats.TryGetValue (Constants.Stats.Resistance, out oldJob.resistance);
		stats.TryGetValue (Constants.Stats.Initiative, out oldJob.initiative);
	}

	public void changeRace(Constants.Races race) {
		Race oldRace = unit.GetComponent<Race> ();
		Dictionary<Constants.Stats, int> stats;
		Constants.raceStats.TryGetValue (race, out stats);

		stats.TryGetValue (Constants.Stats.Health, out oldRace.health);
		stats.TryGetValue (Constants.Stats.Stamina, out oldRace.stamina);
		stats.TryGetValue (Constants.Stats.Mana, out oldRace.mana);
		stats.TryGetValue (Constants.Stats.Speed, out oldRace.speed);
		stats.TryGetValue (Constants.Stats.Spellpower, out oldRace.spellpower);
		stats.TryGetValue (Constants.Stats.Damage, out oldRace.damage);
		stats.TryGetValue (Constants.Stats.Accuracy, out oldRace.accuracy);
		stats.TryGetValue (Constants.Stats.Defense, out oldRace.defense);
		stats.TryGetValue (Constants.Stats.Evasion, out oldRace.evasion);
		stats.TryGetValue (Constants.Stats.Fortitude, out oldRace.fortitude);
		stats.TryGetValue (Constants.Stats.Resistance, out oldRace.resistance);
		stats.TryGetValue (Constants.Stats.Initiative, out oldRace.initiative);
	}
}

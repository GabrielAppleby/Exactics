﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//Eventually I need to go back and handle if
//TryGetValue fails

public class UnitCreation : MonoBehaviour {


	ObjectFactory objectFactory;
	GameObject unit;

	private void Start () {
		objectFactory = new ObjectFactory ();
		unit = objectFactory.createUnit ();
	}


	public void changeJob(GameObject entity, Constants.Jobs job) {
		Dictionary<Constants.Stats, int> stats;
		Constants.jobStats.TryGetValue (job, out stats);
		updateStats (entity, stats);
	}

	public void changeRace(GameObject entity, Constants.Races race) {
		Dictionary<Constants.Stats, int> stats;
		Constants.raceStats.TryGetValue (race, out stats);
		updateStats (entity, stats);
	}

	private void updateStats(GameObject entity, Dictionary<Constants.Stats, int> stats) {
		Defense defense = entity.GetComponent<Defense> ();
		Initiative initiative = entity.GetComponent<Initiative> ();
		Mana mana = entity.GetComponent<Mana> ();
		Movement movement = entity.GetComponent<Movement> ();
		Offense offense = entity.GetComponent<Offense> ();
		Stamina stamina = entity.GetComponent<Stamina> ();

		stats.TryGetValue (Constants.Stats.Health, out defense.health);
		stats.TryGetValue (Constants.Stats.Stamina, out stamina.stamina);
		stats.TryGetValue (Constants.Stats.Mana, out mana.mana);
		stats.TryGetValue (Constants.Stats.Move, out movement.movement);
		stats.TryGetValue (Constants.Stats.Spellpower, out offense.spellpower);
		stats.TryGetValue (Constants.Stats.Damage, out offense.damage);
		stats.TryGetValue (Constants.Stats.Accuracy, out offense.accuracy);
		stats.TryGetValue (Constants.Stats.Defense, out defense.defense);
		stats.TryGetValue (Constants.Stats.Evasion, out defense.evasion);
		stats.TryGetValue (Constants.Stats.Fortitude, out defense.fortitude);
		stats.TryGetValue (Constants.Stats.Resistance, out defense.resistance);
		stats.TryGetValue (Constants.Stats.Initiative, out initiative.initiative);
	}
}
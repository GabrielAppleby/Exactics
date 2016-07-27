﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UnitScript : MonoBehaviour {
	private Constants.Classes clss;
	private Constants.Races race;
	public TileScript tileScript { get; set; }

	public Dictionary<Constants.Stats, int> stats; 

	public void init(Constants.Classes clss, Constants.Races race) {
		this.clss = clss;
		this.race = race;
		stats = new Dictionary<Constants.Stats, int> ();
		calculateStats ();
	}

	public void setClass(Constants.Classes clss) {
		this.clss = clss;
		calculateStats ();
	}

	public void setRace(Constants.Races race) {
		this.race = race;
		calculateStats ();
	}


	public void calculateStats() {
		foreach (Constants.Stats stat in Enum.GetValues(typeof(Constants.Stats))) {
			Dictionary<Constants.Stats, int> raceValues;
			Dictionary<Constants.Stats, int> classValues;
			Constants.raceStats.TryGetValue (race, out raceValues);
			Constants.classStats.TryGetValue (clss, out classValues);
			int raceValue;
			int classValue;

			raceValues.TryGetValue (stat, out raceValue);
			classValues.TryGetValue (stat, out classValue);


			stats[stat] = raceValue + classValue;
		}
	}
		

	public void printStats() {
		Debug.Log(race.ToString() + " + " + clss.ToString());
		foreach (Constants.Stats stat in Enum.GetValues(typeof(Constants.Stats))) {
			int statValue;
			stats.TryGetValue(stat, out statValue);
			Debug.Log (statValue);
		}
	}
		
}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UnitScript : MonoBehaviour {
	private Constants.Classes clss;
	private Constants.Races race;

	public Dictionary<Constants.Stats, int> stats; 

	public void Init(Constants.Classes clss, Constants.Races race) {
		this.clss = clss;
		this.race = race;
		stats = new Dictionary<Constants.Stats, int> ();
		CalculateStats ();
	}

	public void setClass(Constants.Classes clss) {
		this.clss = clss;
		CalculateStats ();
	}

	public void setRace(Constants.Races race) {
		this.race = race;
		CalculateStats ();
	}


	public void CalculateStats() {
		foreach (Constants.Stats stat in Enum.GetValues(typeof(Constants.Stats))) {
			Dictionary<Constants.Stats, int> raceValues;
			Dictionary<Constants.Stats, int> classValues;
			Constants.raceStats.TryGetValue (race, out raceValues);
			Constants.classStats.TryGetValue (clss, out classValues);
			int raceValue;
			int classValue;

			raceValues.TryGetValue (stat, out raceValue);
			classValues.TryGetValue (stat, out classValue);


			stats.Add(stat, raceValue + classValue);
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

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UnitScript : MonoBehaviour {
	private Constants.Classes clss;
	private Constants.Races race;
	public TileScript tileScript { get; set; }
	private int speed;
	public Dictionary<Constants.Stats, int> stats;
	private Grid floorGrid;
	public bool selected { get; set; }
	public Dictionary<TileScript, TileScript> cameFrom;
	private BoardManager boardManagerInstance;

	public void init(Constants.Classes clss, Constants.Races race, BoardManager boardManagerInstance) {
		this.clss = clss;
		this.race = race;
		this.boardManagerInstance = boardManagerInstance;
		this.floorGrid = boardManagerInstance.floorGrid;
		stats = new Dictionary<Constants.Stats, int> ();
		calculateStats ();
		selected = false;
		cameFrom = new Dictionary<TileScript, TileScript> ();
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

	public void OnMouseUp() {
		if (selected == false) {
			stats.TryGetValue (Constants.Stats.Speed, out speed);
			cameFrom = floorGrid.test(speed, tileScript);
			selected = true;
			boardManagerInstance.unitScript = this;
			boardManagerInstance.unitSelected = true;
		}

	}
		
}

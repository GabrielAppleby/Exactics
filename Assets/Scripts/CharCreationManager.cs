using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class CharCreationManager : MonoBehaviour {
	private BoardManager boardManagerInstance;
	private UnitScript unitScript;
	private ArrayList sliders;
	public Dictionary<Constants.Stats, Text> textValues; 

	private Dictionary<int, Constants.Races> raceDropdown = new Dictionary <int, Constants.Races>() {
		{0, Constants.Races.Race},
		{1, Constants.Races.Human},
		{2, Constants.Races.Goblin},
		{3, Constants.Races.Daemon},
		{4, Constants.Races.Fae},
		{5, Constants.Races.Tegimin},
		{6, Constants.Races.Avian}
	};
	private Dictionary<int, Constants.Classes> classDropdown = new Dictionary <int, Constants.Classes>() {
		{0, Constants.Classes.Class},
		{1, Constants.Classes.Monk},
		{2, Constants.Classes.Ninja},
		{3, Constants.Classes.Sage},
		{4, Constants.Classes.Champion},
		{5, Constants.Classes.Templar},
		{6, Constants.Classes.Inquisitor},
		{7, Constants.Classes.Ranger},
		{8, Constants.Classes.Skirmisher},
		{9, Constants.Classes.Archer},
		{10, Constants.Classes.Spellsword},
		{11, Constants.Classes.Hexblade},
		{12, Constants.Classes.Shadowdancer},
		{13, Constants.Classes.Shaman},
		{14, Constants.Classes.Druid},
		{15, Constants.Classes.Healer},
		{16, Constants.Classes.Warrior},
		{17, Constants.Classes.Defender},
		{18, Constants.Classes.Berserker},
		{19, Constants.Classes.Mage},
		{20, Constants.Classes.Arcanist},
		{21, Constants.Classes.Summoner},
		{22, Constants.Classes.Rogue},
		{23, Constants.Classes.Assassin},
		{24, Constants.Classes.Duelist},
		{25, Constants.Classes.Cleric},
		{26, Constants.Classes.Mystic},
		{27, Constants.Classes.Warpriest}
	};

	private void Awake() {
		textValues = new Dictionary<Constants.Stats, Text> ();
		boardManagerInstance = gameObject.GetComponent<BoardManager> ();
		unitScript = boardManagerInstance.createUnit ("Unit", new Coordinate (-100, -100, -100, -100));
		createText ();
	}

	private void Start() {
		
	}


	public void dropDownValueChange(Dropdown dropdown) {
		if (dropdown.name == "Race Dropdown") {
			Constants.Races newRace;
			raceDropdown.TryGetValue (dropdown.value, out newRace);
			unitScript.setRace(newRace);
		} else {
			Constants.Classes newClass;
			classDropdown.TryGetValue (dropdown.value, out newClass);
			unitScript.setClass(newClass);
		}
		updateStats ();
	}

	private void updateStats() {
		int value;
		foreach (KeyValuePair<Constants.Stats, Text> entry in textValues) {
			unitScript.stats.TryGetValue(entry.Key, out value);
			entry.Value.text = value.ToString ();
		}

	}

	private void createText() {
		Font arialFont = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");
		GameObject canvas = GameObject.Find ("Canvas");
		GameObject textObject;
		RectTransform rectTransform;
		Text text;
		float xCurrent;
		float yInterval = 65f;
		float yStart = 225f;
		float yCurrent = yStart;
		String strText;
		String strName;
		System.Array allStats = Enum.GetValues (typeof(Constants.Stats));
		Constants.Stats stat;
		int n = allStats.Length / 2;
		for (int i = 0; i < allStats.Length; i++) {
			stat = (Constants.Stats) allStats.GetValue(i);
			strText = stat.ToString () + ": ";
			strName = "Text: " + stat.ToString ();
			if (i >= n) {
				xCurrent = 196;
			} else {
				xCurrent = -16f;
			}
			if (i == 6) {
				yCurrent = yStart;
			}
			yCurrent -= yInterval;
			for (int j = 0; j < 2; j++) {
				textObject = new GameObject (strName);
				textObject.layer = 5;
				textObject.transform.SetParent (canvas.transform);
				rectTransform = textObject.AddComponent<RectTransform> ();
				textObject.AddComponent<CanvasRenderer> ();
				text = textObject.AddComponent<Text> ();
				if (j == 1) {
					xCurrent += 106;
					strText = "0";
					strName = "Text: " + stat.ToString () + " value";
					textValues.Add (stat, text);
				}
				text.text = strText;
				text.font = arialFont;
				text.color = Color.black;
				text.alignment = TextAnchor.MiddleCenter;
				rectTransform.sizeDelta = new Vector2 (100f, 20f);
				rectTransform.localScale = new Vector3 (1f, 1f, 1f);
				textObject.transform.localPosition = new Vector3 (xCurrent, yCurrent, 0);
			}
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharCreationManager : MonoBehaviour {
	private BoardManager boardManagerInstance;
	private UnitScript unitScript;
	private Slider[] sliders;

	private Dictionary<int, Constants.Races> raceDropdown = new Dictionary <int, Constants.Races>() {
		{0, Constants.Races.Human},
		{0, Constants.Races.Goblin},
		{0, Constants.Races.Daemon},
		{0, Constants.Races.Fae},
		{0, Constants.Races.Tegimin},
		{0, Constants.Races.Avian}
	};
	private Dictionary<int, Constants.Classes> classDropdown = new Dictionary <int, Constants.Classes>() {
		{0, Constants.Classes.Monk},
		{1, Constants.Classes.Ninja},
		{2, Constants.Classes.Sage},
		{3, Constants.Classes.Champion},
		{4, Constants.Classes.Templar},
		{5, Constants.Classes.Inquisitor},
		{6, Constants.Classes.Ranger},
		{7, Constants.Classes.Skirmisher},
		{8, Constants.Classes.Archer},
		{9, Constants.Classes.Spellsword},
		{10, Constants.Classes.Hexblade},
		{11, Constants.Classes.Shadowdancer},
		{12, Constants.Classes.Shaman},
		{13, Constants.Classes.Druid},
		{14, Constants.Classes.Healer},
		{15, Constants.Classes.Warrior},
		{16, Constants.Classes.Defender},
		{17, Constants.Classes.Berserker},
		{18, Constants.Classes.Mage},
		{19, Constants.Classes.Arcanist},
		{20, Constants.Classes.Summoner},
		{21, Constants.Classes.Rogue},
		{22, Constants.Classes.Assassin},
		{23, Constants.Classes.Duelist},
		{24, Constants.Classes.Cleric},
		{25, Constants.Classes.Mystic},
		{26, Constants.Classes.Warpriest}
	};


	private void Awake() {
		
		boardManagerInstance = gameObject.GetComponent<BoardManager> ();
		unitScript = boardManagerInstance.createUnit (name, new Coordinate (-100, -100, -100, -100));
		sliders = GameObject.Find ("Canvas").GetComponents<Slider> ();
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
		SliderScript temp;
		int i;
		foreach (Slider slider in sliders) {
			temp = slider.GetComponent<SliderScript> ();
			unitScript.stats.TryGetValue (temp.stat, out i);
			temp.UpdateSlider((float) i);
		}
	}

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharCreationManager : MonoBehaviour {
	private BoardManager boardManagerInstance;
	private UnitScript unitScript;
	private ArrayList sliders;

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
	//EventSystem
	//DropDown with a 
		//Rect transform
		//Canvas Renderer
		//Image
		//Dropdown script

	private void Awake() {
		/*GameObject canvasObject = new GameObject ("Canvas");
		canvasObject.AddComponent<RectTransform> ();
		Canvas canvas = canvasObject.AddComponent<Canvas> ();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		canvasObject.AddComponent<CanvasScaler> ();
		canvasObject.AddComponent<GraphicRaycaster> ();
		canvasObject.AddComponent<CanvasRenderer> ();
		canvasObject.AddComponent<Image> ();
		GameObject events = new GameObject ("EventSystem");
		GameObject dropDown = new GameObject ("Dropdown");
		dropDown.transform.SetParent(canvasObject.transform);
		RectTransform rectTransform = dropDown.AddComponent<RectTransform> ();
		dropDown.AddComponent<CanvasRenderer> ();
		dropDown.AddComponent<Image> ();
		dropDown.AddComponent<Dropdown> ();
		GameObject label = new GameObject ("Label");
		label.AddComponent<RectTransform> ();
		label.AddComponent<CanvasRenderer> ();
		label.AddComponent<Text> ();
		label.transform.SetParent(dropDown.transform);

		GameObject arrow = new GameObject ("Arrow");
		arrow.AddComponent<RectTransform> ();
		arrow.AddComponent<CanvasRenderer> ();
		arrow.AddComponent<Image> ();
		arrow.transform.SetParent(dropDown.transform);*/

		boardManagerInstance = gameObject.GetComponent<BoardManager> ();
		unitScript = boardManagerInstance.createUnit (name, new Coordinate (-100, -100, -100, -100));
	}

	private void Start() {
		/*(GameObject sliderHolder = GameObject.Find ("Sliders");
		sliders = new ArrayList();
		foreach (Transform child in sliderHolder.transform)
		{
			sliders.Add(child.GetComponent<Slider> ());
		}*/
	}


	public void dropDownValueChange(Dropdown dropdown) {
		if (dropdown.name == "Race Dropdown") {
			Constants.Races newRace;
			raceDropdown.TryGetValue (dropdown.value, out newRace);
			if (newRace == null) {
				Debug.Log ("hi");
			}

			unitScript.setRace(newRace);
		} else {
			Constants.Classes newClass;
			classDropdown.TryGetValue (dropdown.value, out newClass);
			unitScript.setClass(newClass);
		}/*
		SliderScript temp;
		int i;
		foreach (Slider slider in sliders) {
			temp = slider.GetComponent<SliderScript> ();
			unitScript.stats.TryGetValue (temp.stat, out i);
			temp.updateSlider((float) i);
		}*/
	}

}

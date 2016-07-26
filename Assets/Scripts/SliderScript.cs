using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderScript : MonoBehaviour {

	private Slider slider;
	private Text field;
	public Constants.Stats stat { get; set;}

	// Use this for initialization
	void Start () {
		slider = gameObject.GetComponent<Slider> ();
		field = gameObject.GetComponent<Text> ();
		stat = Constants.Stats.Health;
	}

	public void updateSlider(float update) {
		if (field != null) {
			slider.value = update;
			field.text = update.ToString ();
		}

	}
}

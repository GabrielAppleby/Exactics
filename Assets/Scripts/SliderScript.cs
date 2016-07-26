using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderScript : MonoBehaviour {

	private Slider slider;
	public Constants.Stats stat { get; set;}

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Slider> ();
		stat = Constants.Stats.Health;
	}

	public void UpdateSlider(float update) {
		if (slider != null) {
			slider.value = Mathf.MoveTowards (slider.value, update, 0.15f);
		}
	}
}

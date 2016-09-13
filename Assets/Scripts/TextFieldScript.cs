using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//A Topas Class
//Don't forget accidently delete

public class TextFieldScript : MonoBehaviour {
	private void Start ()
	{
		InputField inputField = gameObject.GetComponent<InputField>();
		InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();
		submitEvent.AddListener(submitName);
		inputField.onEndEdit = submitEvent;

		//or simply use the line below, 
		//input.onEndEdit.AddListener(SubmitName);  // This also works
	}

	private void submitName(string arg0)
	{
		Debug.Log(arg0);
	}
}
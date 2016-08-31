using UnityEngine;
using System.Collections;

public class InputSystem : MonoBehaviour {

	public delegate void HighlightMovement(GameObject e, int speed);
	public static event HighlightMovement highlight;

	void OnEnable()
	{
		Input.onClick += directClick;
	}


	void OnDisable()
	{
		Input.onClick -= directClick;
	}

	void directClick(GameObject entity) {
		Debug.Log (entity);
		Movement movementComponent = entity.GetComponent<Movement> ();
		if (movementComponent != null) {
			int speed = entity.GetComponent<Job> ().speed + entity.GetComponent<Race> ().speed;
			highlight (entity, speed);
		}
	}
}

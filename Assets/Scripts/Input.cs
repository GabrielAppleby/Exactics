using UnityEngine;
using System.Collections;

public class Input : MonoBehaviour {

	public delegate void ClickEventHandler(GameObject e);
	public static event ClickEventHandler onClick;

	private void OnMouseUp() {
		if (onClick != null) {
			onClick (gameObject);
		}
	}
}

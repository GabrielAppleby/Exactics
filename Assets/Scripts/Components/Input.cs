using UnityEngine;
using System.Collections;

public class Input : MonoBehaviour {

	public delegate void ClickEventHandler(GameObject e);
	public static event ClickEventHandler onClick;

	public delegate void HoverEventHandler(GameObject e);
	public static event HoverEventHandler onHover;

	private void OnMouseUp() {
		if (onClick != null) {
			onClick (gameObject);
		}
	}

	private void OnMouseOver() {
		if (onHover != null) {
			onHover (gameObject);
		}
	}
}

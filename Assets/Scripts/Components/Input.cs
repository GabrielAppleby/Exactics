using UnityEngine;

public class Input : MonoBehaviour {

	public delegate void ClickEventHandler(GameObject e);
	public static event ClickEventHandler onClick;

	public delegate void MouseEnterEventHandler(GameObject e);
	public static event MouseEnterEventHandler onMouseEnter;

	private void OnMouseUp() {
		if (onClick != null) {
			onClick (gameObject);
		}
	}

	private void OnMouseEnter() {
		if (onMouseEnter != null) {
			onMouseEnter (gameObject);
		}
	}
}

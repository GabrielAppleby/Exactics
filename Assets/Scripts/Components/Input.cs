using UnityEngine;

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

	private void OnMouseEnter() {
		if (onHover != null) {
			onHover (gameObject);
		}
	}
}

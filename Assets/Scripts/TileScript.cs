using UnityEngine;
using UnityEditor;

using System.Collections;

public class TileScript : MonoBehaviour {
	//Need to get grid somehow

	public Coordinate coord { get; set;}
	private SpriteRenderer spriteRenderer;

	public void Init(Coordinate coord, SpriteRenderer spriteRenderer) {
		this.coord = coord;
		this.spriteRenderer = spriteRenderer;
	}

	/*void OnMouseEnter() {
	}

	void OnMouseExit() {
	}

	void OnMouseUp() {
	}*/
}

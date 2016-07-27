using UnityEngine;
using UnityEditor;

using System.Collections;

public class TileScript : MonoBehaviour {
	//Need to get grid somehow

	//Grid class that will store our tiles for easy access
	private Grid floorGrid;

	public Coordinate coord { get; set;}
	private SpriteRenderer spriteRenderer;
	private BoardManager boardManagerInstance;
	public TileScript[] neighbors = new TileScript[6];

	public void init(Coordinate coord, SpriteRenderer spriteRenderer, BoardManager boardManagerInstance) {
		this.coord = coord;
		this.spriteRenderer = spriteRenderer;
		this.boardManagerInstance = boardManagerInstance;
		this.floorGrid = boardManagerInstance.floorGrid;
	}

	public void changeColor(Color temp) {
		spriteRenderer.color = temp;

	}

	public TileScript[] getNeighbors() {

		neighbors[0] = floorGrid.get(coord.x, coord.y - 1);
		neighbors[1] = floorGrid.get(coord.x + 1, coord.y - 1);
		neighbors[2] = floorGrid.get(coord.x - 1, coord.y);
		neighbors[3] = floorGrid.get(coord.x + 1, coord.y);
		neighbors[4] = floorGrid.get(coord.x - 1, coord.y + 1);
		neighbors[5] = floorGrid.get(coord.x, coord.y + 1);

		return neighbors;
	}

	void OnMouseUp() {
		if (boardManagerInstance.unitSelected == true) {
			if (boardManagerInstance.unitScript.cameFrom.ContainsKey (this)) {
				boardManagerInstance.unitScript.selected = false;
				boardManagerInstance.unitSelected = false;
				boardManagerInstance.unitScript.transform.position = this.transform.position;
				boardManagerInstance.unitScript.tileScript = this;
				foreach (TileScript tileScript in boardManagerInstance.unitScript.cameFrom.Keys) {
					tileScript.changeColor (Color.white);
				}
			}
		}
	}
}

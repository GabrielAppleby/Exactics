using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;





public class BoardSetup : MonoBehaviour {


	//This event is fired after the grid has been created.
	public delegate void GridCreated(GameObject[] startTiles);
	public static event GridCreated gridCreated;


	private void Start () {
		//For now hardcoding name/map
		string mapName = "DebugNew";
		GameObject map = createMap (mapName);

		//This is a temporary solution for testing
		Grid grid = createGrid (map);
		GameObject[] startTiles = new GameObject[6];
		startTiles [0] = grid.get (5, 18);
		startTiles [1] = grid.get (6, 18);
		startTiles [2] = grid.get (7, 18);
		startTiles [3] = grid.get (11, 2);
		startTiles [4] = grid.get (12, 2);
		startTiles [5] = grid.get (13, 2);

		if (gridCreated != null) {
			gridCreated (startTiles);
		}

	}

	//Creating, and attempting to center the map
	private GameObject createMap(string mapName) {
		GameObject map = (GameObject) Instantiate(Resources.Load<GameObject>(mapName));
		Tiled2Unity.TiledMap tiledMap = map.GetComponent<Tiled2Unity.TiledMap> ();
		float x = (-tiledMap.MapWidthInPixels / 2f) / 100f;
		float y = (tiledMap.MapHeightInPixels / 2f) / 100f;
		map.GetComponent<Transform> ().position = new Vector3 (x, y, 0);
		return map;
	}



	//Sort of redudant with stuff done on import of map
	//From tiled, but for some reason custom data structures
	//Don't seem to survive the import process :S
	private Grid createGrid(GameObject map) {
		//Create a list to store all our tiles
		Grid grid = new Grid();
		Transform mapTransform = map.GetComponent<Transform> ();
		//Put all of the tiles in our list
		foreach (Transform child in mapTransform) {
			if (child.name.StartsWith ("obj")) {
				foreach (Transform nestedChild in child) {
					grid.add (nestedChild.gameObject);
				}
			}
		}
		return grid;
	}

		
}
	
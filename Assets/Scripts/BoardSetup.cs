using UnityEngine;
using UnityEditor;
using System.Collections;





public class BoardSetup : MonoBehaviour {

	//public delegate void GridCreated(Grid grid);
	//public static event GridCreated gridCreated;

	public delegate void GridReadyForUnits(GameObject[] startTiles);
	public static event GridReadyForUnits gridReadyForUnits;


	//Happens after awake, before first update.
	//Does not happen if component not enabled
	private void Start () {
		string mapName = "DebugMap";
		GameObject map = createMap (mapName);
		Grid grid = createGrid (map);
		GameObject[] startTiles = new GameObject[1];
		startTiles [0] = grid.get (13, 6);
		gridReadyForUnits (startTiles);
		//gridCreated (grid);

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
	//From tiled, I may just have the grid generated at import
	//and throw it into an object attached to the prefab
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
	
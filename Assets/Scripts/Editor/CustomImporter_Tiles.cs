using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Tiled2Unity.CustomTiledImporter]

public class CustomImporter_Tiles : Tiled2Unity.ICustomTiledImporter
{

	public void HandleCustomProperties(GameObject gameObject,
		IDictionary<string, string> customProperties)
	{
		//Debug.Log (gameObject.GetComponent<Transform>().position);
		//Object.DestroyImmediate (gameObject.GetComponent<EdgeCollider2D> ());
	}

	//This is a bad way to do this, maybe it is easier
	//to do from within Tiled?
	//Also why in gods name does tiled use offset coordinates instead of axial?
	//Its strictly worse in every way
	public void CustomizePrefab(GameObject prefab)
	{
		//Grab the script that has the number of tiles in each column and row
		Tiled2Unity.TiledMap info = prefab.GetComponent<Tiled2Unity.TiledMap> ();
		//Number of tiles in a row
		int tilesWide = info.NumTilesWide;
		int tilesHigh = info.NumTilesHigh;

		List<GameObject> tiles = aggregateTiles (prefab);

		//Sort the tiles by y then by x (smaller y/x first)
		tiles.Sort (new CoordinateCompare());

		setLocationAndNeighbors (tiles, tilesWide, tilesHigh); 
	}

	private List<GameObject> aggregateTiles(GameObject prefab) {
		//Create a list to store all our tiles
		List<GameObject> tiles = new List<GameObject> ();
		Transform prefabTransform = prefab.GetComponent<Transform> ();
		//Put all of the tiles in our list
		foreach (Transform child in prefabTransform) {
			if (child.name.StartsWith ("obj")) {
				foreach (Transform nestedChild in child) {
					tiles.Add (nestedChild.gameObject);
				}
			}
		}
		return tiles;
	}

	private void setLocationAndNeighbors(List<GameObject> tiles, int tilesWide, int tilesHigh) {
		FakeTransform temp;
		int x = -1;
		int y = -1;
		int parity = 1;
		//Order of foreach with List is not explicitly documented
		//So using for loop so it doesnt randomly change with an update
		for (int i = 0; i < tiles.Count; i++) {
			//Add a fake transform
			temp = tiles [i].AddComponent<FakeTransform> ();

			//Next column
			x++;

			//Set neighbors
			//if we're on a new row within list, switch parity
			//since we're using an offset hexagon map
			if ((i % (tilesWide)) == 0) {
				parity ^= 1;
				//new Row
				y++;
				x = 0;
			}

			//Set fake transform's position
			temp.position.Set(x, y);

			//If we're on an odd parity neighbor coords are
			if (parity == 1) {
				temp.neighbors [0] = ((x-1 > -1) && (y+1 < tilesHigh)) ? tiles [i+tilesWide-1] : null;
				temp.neighbors [1] = (y+1 < tilesHigh) ? tiles [i + tilesWide] : null;
				temp.neighbors [2] = (x-1 > -1) ? tiles [i-1] : null;
				temp.neighbors [3] = (x+1 < tilesWide) ? tiles [i+1] : null;
				temp.neighbors [4] = ((x-1 > -1 ) && (y-1 > -1)) ? tiles [i-tilesWide-1] : null;
				temp.neighbors [5] = (y-1 > -1) ? tiles [i - tilesWide] : null;
				//Since we're on an even parity neighbor coords are
			} else {
				temp.neighbors [0] = (y+1 < tilesHigh) ? tiles [i + tilesWide] : null;
				temp.neighbors [1] = ((x+1 < tilesWide) && (y+1 < tilesHigh)) ? tiles [i + tilesWide+1] : null;
				temp.neighbors [2] = (x-1 > -1) ? tiles [i-1] : null;
				temp.neighbors [3] = (x+1 < tilesWide) ? tiles [i+1] : null;
				temp.neighbors [4] = (y-1 > -1) ? tiles [i - tilesWide] : null;
				temp.neighbors [5] = ((x+1 < tilesWide) && (y-1 > -1)) ? tiles [i - tilesWide+1] : null;
			}
		}
	}
}

public class CoordinateCompare : Comparer<GameObject>  {
	// Compares by Length, Height, and Width.
	public override int Compare(GameObject one, GameObject two)
	{
		Vector3 onePosition = one.GetComponent<Transform> ().position;
		Vector3 twoPosition = two.GetComponent<Transform> ().position;
		float oneX = onePosition.x;
		float oneY = onePosition.y;
		float twoX = twoPosition.x;
		float twoY = twoPosition.y;


		if (oneY < twoY) {
			return -1;
		}
		else if (oneY > twoY) {
			return 1;
		}
		else if (oneX < twoX) {
			return -1;
		}
		else if (oneX > twoX) {
			return 1;
		}
		return 0;
	}
}
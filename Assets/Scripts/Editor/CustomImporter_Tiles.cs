using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Tiled2Unity.CustomTiledImporter]

public class CustomImporter_Tiles : Tiled2Unity.ICustomTiledImporter
{

	public void HandleCustomProperties(GameObject gameObject,
		IDictionary<string, string> customProperties)
	{
		//Attach a component to contain Tile type and neighbors
		TerrainInfoComponent terrainInfoComponent = gameObject.AddComponent<TerrainInfoComponent> ();

		//Update TerrainInfo component to reflect tile types
		foreach (KeyValuePair<string, string> entry in customProperties) {
			if (entry.Key == "Terrain") {
				switch (entry.Value) {
				case "Water":
					terrainInfoComponent.terrainType = Constants.TerrainTypes.Water;
					break;
				case "Stone":
					terrainInfoComponent.terrainType = Constants.TerrainTypes.Stone;
					break;
				case "Dirt":
					terrainInfoComponent.terrainType = Constants.TerrainTypes.Dirt;
					break;
				default:
					Debug.Log ("Somethings is wrong with Tile Types. (CustomImporter_Tiles line 28)");
					break;
				}
			}

		}
	}

	//Customize the prefab so that fake coordinates
	//and neighbors don't need to be created at runtime
	public void CustomizePrefab(GameObject mapPrefab)
	{
		
		List<GameObject> tiles = aggregateTiles (mapPrefab);


		//Sort the tiles by y then by x (smaller y/x first)
		tiles.Sort (new CoordinateCompare());

		setLocationAndNeighbors (mapPrefab, tiles);


	}

	//Grab all the tile objects and put them in one list
	private List<GameObject> aggregateTiles(GameObject mapPrefab) {
		//Create a list to store all our tiles
		List<GameObject> tiles = new List<GameObject> ();
		Transform mapPrefabTransform = mapPrefab.GetComponent<Transform> ();
		//Put all of the tiles in our list
		foreach (Transform childTransform in mapPrefabTransform) {
			if (childTransform.name.StartsWith ("obj")) {
				foreach (Transform nestedChildTransform in childTransform) {
					tiles.Add (nestedChildTransform.gameObject);
				}
			}
		}
		return tiles;
	}

	private void setLocationAndNeighbors(GameObject mapPrefab, List<GameObject> tiles) {
		Tiled2Unity.TiledMap tileMap = mapPrefab.GetComponent<Tiled2Unity.TiledMap> ();
		//Grab the number of tiles wide and high for convenience
		int numTilesWide = tileMap.NumTilesWide;
		int numTilesHigh = tileMap.NumTilesHigh;

		//Declare the fake x and y variables before loop
		//Initialized to -1, because incremented at start of loop
		//to solve a fence post
		int x = -1;
		int y = -1;

		//Start with parity = 1
		int parity = 1;



		//Declare before loop

		FakeTransformComponent fakeTransform;
		TerrainInfoComponent terrainInfo;
		Vector2[] points;
		PolygonCollider2D polygonCollider2D;
		EdgeCollider2D edgeCollider2D;

		//Order of foreach with List is not explicitly documented
		//So using for loop so it doesnt randomly change with an update
		for (int i = 0; i < tiles.Count; i++) {
			//Add a fake transform
			fakeTransform = tiles [i].AddComponent<FakeTransformComponent> ();
			//Add the input componenet
			tiles[i].AddComponent<InputComponent>();
			//Add a polygoncollider so input works properly
			polygonCollider2D = tiles[i].AddComponent<PolygonCollider2D>();


			//Get the TerrainInfo component
			terrainInfo = tiles [i].GetComponent<TerrainInfoComponent> ();
			//Get the old edge collider
			edgeCollider2D = tiles[i].GetComponent<EdgeCollider2D> ();


			//Draw the polygonCollider based on the old edgeCollider
			polygonCollider2D.SetPath (0, edgeCollider2D.points);
			//Destroy the old edge collider
			UnityEngine.Object.DestroyImmediate (edgeCollider2D);

			//Next column
			x++;

			//Set neighbors
			//if we're on a new row within list, switch parity
			//since we're using an offset hexagon map
			if ((i % (numTilesWide)) == 0) {
				parity ^= 1;
				//new Row
				y++;
				x = 0;
			}

			//Set fake transform's position
			fakeTransform.position = new Vector3(x, y, 0);

			//If we're on an odd parity neighbor coords are
			if (parity == 1) {
				terrainInfo.neighbors [0] = ((x-1 > -1) && (y+1 < numTilesHigh)) ? tiles [i+numTilesWide-1] : null;
				terrainInfo.neighbors [1] = (y+1 < numTilesHigh) ? tiles [i + numTilesWide] : null;
				terrainInfo.neighbors [2] = (x-1 > -1) ? tiles [i-1] : null;
				terrainInfo.neighbors [3] = (x+1 < numTilesWide) ? tiles [i+1] : null;
				terrainInfo.neighbors [4] = ((x-1 > -1 ) && (y-1 > -1)) ? tiles [i-numTilesWide-1] : null;
				terrainInfo.neighbors [5] = (y-1 > -1) ? tiles [i - numTilesWide] : null;
				//Since we're on an even parity neighbor coords are
			} else {
				terrainInfo.neighbors [0] = (y+1 < numTilesHigh) ? tiles [i + numTilesWide] : null;
				terrainInfo.neighbors [1] = ((x+1 < numTilesWide) && (y+1 < numTilesHigh)) ? tiles [i + numTilesWide+1] : null;
				terrainInfo.neighbors [2] = (x-1 > -1) ? tiles [i-1] : null;
				terrainInfo.neighbors [3] = (x+1 < numTilesWide) ? tiles [i+1] : null;
				terrainInfo.neighbors [4] = (y-1 > -1) ? tiles [i - numTilesWide] : null;
				terrainInfo.neighbors [5] = ((x+1 < numTilesWide) && (y-1 > -1)) ? tiles [i - numTilesWide+1] : null;
			}

		}
	}
		
	//Compares coordinates, by Y then by X
	private sealed class CoordinateCompare : Comparer<GameObject>  {
		public override int Compare(GameObject one, GameObject two)
		{
			Vector3 onePosition = one.GetComponent<Transform> ().position;
			Vector3 twoPosition = two.GetComponent<Transform> ().position;
			double oneX = Math.Round((double) onePosition.x, 2);
			double oneY = Math.Round((double) onePosition.y, 2);
			double twoX = Math.Round((double) twoPosition.x, 2);
			double twoY = Math.Round((double) twoPosition.y, 2);
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
}


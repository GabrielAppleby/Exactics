using UnityEngine;
using Entitas;
using System.Collections.Generic;
using System;

public sealed class CreateGameMapSystem : IInitializeSystem, ISetPool {
	Pool _pool;
	//This is a github test

	public void SetPool(Pool pool) {
		_pool = pool;
	}

	public void Initialize() {
		//Boolean representing whether or not someone can walk on a tile
		bool impassable; 

		//A temporary referance to the tile entity, to revent a large one liner
		Entity tileEntity;

		//Refernce to neighboring entities
		Entity[] neighbors;

		//List to termporarily hold tile entities
		List<Entity> tiles = new List<Entity> ();


		//Intantiates the Tiled map prefab
		GameObject map = (GameObject) UnityEngine.Object.Instantiate(Resources.Load<GameObject>("DebugNew"));

		//Transform of the map, that I think avoids multiple GetComponent calls in the foreach loop
		Transform mapTransform = map.GetComponent<Transform> ();

		//Tiled map info necessary to create fake coordinates, and log neighbors easily
		Tiled2Unity.TiledMap tileMap = map.GetComponent<Tiled2Unity.TiledMap> ();

		//map.transform.position = new Vector2 ((tileMap.MapWidthInPixels / -2f), (tileMap.MapHeightInPixels / 2f));

		//Storing inside local intergers for convenience
		int numTilesWide = tileMap.NumTilesWide;
		int numTilesHigh = tileMap.NumTilesHigh;

		//Sets the rows and columns of the game map component
		_pool.SetGameMap(numTilesWide, numTilesHigh);

		//Fake x and y coordinates initialized to -1, because incremented at start of loop to solve a fence post
		int x = -1;
		int y = -1;

		//Start with parity = 1 (We want to change neighbor calculations slightly based on parity, since using offset tiles)
		int parity = 1;

		foreach (Transform child in mapTransform) {
			if (child.name != "Terrain") {
				if (child.name == "Stone") {
					impassable = true;
				} else {
					impassable = false;
				}
				foreach (Transform nestedChild in child) {
					tileEntity = _pool.CreateEntity ()
						.AddPosition (nestedChild.position.x, nestedChild.position.y)
						.IsGameMapElement (true)
						.IsInteractive (true)
						.IsImpassable (impassable);
					tiles.Add (tileEntity);
				}
			}
		}

		//Sort the tiles by y then by x (smaller y/x first)
		tiles.Sort (new CoordinateCompare());


		//Order of foreach with List is not explicitly documented, so using for loop so it doesnt randomly change with an update
		for (int i = 0; i < tiles.Count; i++) {
			//create a new neighbors array for each tile
			neighbors = new Entity[6];


			//Next column
			x++;

			//if we're on a new row within list, switch parity since we're using an offset hexagon map
			if ((i % (numTilesWide)) == 0) {
				parity ^= 1;
				//new Row
				y++;
				x = 0;
			}


			//Add a fakeposition
			tiles [i].AddFakePosition (x, y);


			//If we're on an odd parity neighbor coords are
			if (parity == 1) {
				neighbors [0] = ((x-1 > -1) && (y+1 < numTilesHigh)) ? tiles [i+numTilesWide-1] : null;
				neighbors [1] = (y+1 < numTilesHigh) ? tiles [i + numTilesWide] : null;
				neighbors [2] = (x-1 > -1) ? tiles [i-1] : null;
				neighbors [3] = (x+1 < numTilesWide) ? tiles [i+1] : null;
				neighbors [4] = ((x-1 > -1 ) && (y-1 > -1)) ? tiles [i-numTilesWide-1] : null;
				neighbors [5] = (y-1 > -1) ? tiles [i - numTilesWide] : null;
				//Since we're on an even parity neighbor coords are
			} else {
				neighbors [0] = (y+1 < numTilesHigh) ? tiles [i + numTilesWide] : null;
				neighbors [1] = ((x+1 < numTilesWide) && (y+1 < numTilesHigh)) ? tiles [i + numTilesWide+1] : null;
				neighbors [2] = (x-1 > -1) ? tiles [i-1] : null;
				neighbors [3] = (x+1 < numTilesWide) ? tiles [i+1] : null;
				neighbors [4] = (y-1 > -1) ? tiles [i - numTilesWide] : null;
				neighbors [5] = ((x+1 < numTilesWide) && (y-1 > -1)) ? tiles [i - numTilesWide+1] : null;
			}

			//Add the neighors array
			tiles [i].AddNeighbors (neighbors);
		}

	}





	//Compares coordinates, by Y then by X
	private sealed class CoordinateCompare : Comparer<Entity>  {
		public override int Compare(Entity one, Entity two)
		{
			double oneX = Math.Round((double) one.position.x, 2);
			double oneY = Math.Round((double) one.position.y, 2);
			double twoX = Math.Round((double) two.position.x, 2);
			double twoY = Math.Round((double) two.position.y, 2);
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

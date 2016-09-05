using UnityEngine;
using System.Collections.Generic;

public class Grid {

	private Dictionary<int, GameObject> tiles;

	public Grid() {
		tiles = new Dictionary<int, GameObject>();
	}

	public void add(GameObject tile) {
		tiles.Add(hashCode(tile), tile);
	}

	//Gets a tile based on hashcode
	public GameObject get(int hashCode) {
		GameObject value;
		tiles.TryGetValue(hashCode, out value);
		return value;
	}


	//Removes a tile based on hashcode
	public void remove(int hashCode) {
		tiles.Remove (hashCode);
	}

	public int hashCode(int x, int y) {
		int hash = 17;
		hash = ((hash + x) << 5) - (hash + x);
		hash = ((hash + y) << 5) - (hash + y);
		return hash;
	}

	private int hashCode(GameObject tile) {
		return hashCode(tile.GetComponent<FakeTransform>().position);
	}

	private int hashCode(Vector2 fakePosition) {
		return hashCode ((int) fakePosition.x, (int) fakePosition.y);
	}

	/*
	public Dictionary<GameObject> getMovement(int moveSpeed, GameObject tempTile) {
		Queue<Helper> frontier = new Queue<Helper> ();
		Dictionary<GameObject, GameObject> cameFrom = new Dictionary<GameObject, GameObject>();
		Helper tempHelper = new Helper (moveSpeed, tempTile);
		frontier.Enqueue (tempHelper);
		cameFrom.Add (tempTile, null);
		while (frontier.Count != 0) {
			tempHelper = frontier.Dequeue ();
			if (tempHelper.steps > 0) {
				//Where should neighbors be stored?
				foreach (GameObject neighbor in tempHelper.entity.neighbors) {
					if (neighbor != null) {
						if (cameFrom.ContainsKey (neighbor) == false) {
							frontier.Enqueue (new Helper (tempHelper.steps - 1, neighbor));
							neighbor.changeColor (Color.blue);
							cameFrom.Add (neighbor, tempHelper.tileScript);
						}
					}
				}
			}
		}
		return cameFrom;
	}

	public class Helper {
		public int steps { get; set; }
		public GameObject entity { get; set; }

		public Helper(int steps, GameObject entity) {
			this.steps = steps;
			this.entity = entity;

		}


	}*/


	/*//Manhattan distance
	public int heuristic(TileScript tileScriptA, TileScript tileScriptB) {
		return Mathf.Abs(tileScriptA.coord.x - tileScriptB.coord.x) + Mathf.Abs(tileScriptA.coord.y - tileScriptB.coord.y);
	}*/
		
}

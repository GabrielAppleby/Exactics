using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid {

	private Dictionary<int, GameObject> tiles;

	public Grid() {
		tiles = new Dictionary<int, GameObject>();
	}

	public void Add(GameObject tile) {
		tiles.Add(hashCode(tile), tile);
	}

	//Gets a tile based on hashcode
	public GameObject Get(int hashCode) {
		GameObject value;
		tiles.TryGetValue(hashCode, out value);
		return value;
	}

	//Removes a tile based on object
	public void Remove(GameObject tile) {
		Remove(hashCode (tile));
	}


	//Removes a tile based on hashcode
	public void Remove(int hashCode) {
		tiles.Remove (hashCode);
	}

	//A* to find path
	public void findPath(GameObject start, GameObject goal) {
		PriorityQueue<GameObject> frontier = new PriorityQueue<GameObject> ();
		frontier.Enqueue (start, 0);
		Dictionary<GameObject, GameObject> cameFrom = new Dictionary<GameObject, GameObject>();
		Dictionary<GameObject, int> cost = new Dictionary<GameObject, int>();
		cameFrom.Add (start, null);
		cost.Add (start, 0);

		GameObject current;
		while (frontier.Count != 0) {
			current = frontier.Dequeue();
			if (current == goal) {
				break;
			}

			foreach (GameObject neighbor in getNeighbors(current)) {
				int temp;
				cost.TryGetValue (current, out temp);
				int newCost =  temp + 1;
				int value;
				int priority;
				cost.TryGetValue (neighbor, out value);
				if (cost.ContainsKey(neighbor) != true || newCost < value) {
					cost.Add(neighbor, value);
					priority = newCost + Heuristic(goal, neighbor);
					frontier.Enqueue (neighbor, priority);
					cameFrom.Add(neighbor, current);
				}
			}
		}
	}

	//Manhattan distance
	static public int Heuristic(GameObject a, GameObject b) {
		TileScript tileScriptA = a.GetComponent<TileScript> ();
		TileScript tileScriptB = b.GetComponent<TileScript> ();
		return Mathf.Abs(tileScriptA.coord.x - tileScriptB.coord.x) + Mathf.Abs(tileScriptA.coord.y - tileScriptB.coord.y);
	}


	//Update me
	public GameObject[] getNeighbors(GameObject tile) {
		TileScript tileScript = tile.GetComponent<TileScript> ();
		GameObject[] neighbors = new GameObject[6];

		neighbors[0] = Get(hashCode(tileScript.coord.x, tileScript.coord.y + 1));
		neighbors[1] = Get(hashCode(tileScript.coord.x + 1, tileScript.coord.y + 1));
		neighbors[2] = Get(hashCode(tileScript.coord.x + 1, tileScript.coord.y));
		neighbors[3] = Get(hashCode(tileScript.coord.x, tileScript.coord.y - 1));
		neighbors[4] = Get(hashCode(tileScript.coord.x - 1, tileScript.coord.y - 1));
		neighbors[5] = Get(hashCode(tileScript.coord.x -1, tileScript.coord.y));

		return neighbors;
	}

	public int hashCode(int x, int y) {
		int hash = 17;
		hash = ((hash + x) << 5) - (hash + x);
		hash = ((hash + y) << 5) - (hash + y);
		return hash;
	}

	private int hashCode(GameObject tile) {
		Coordinate coord = tile.GetComponent<TileScript>().coord;
		return hashCode (coord.x, coord.y);
	}
		
}

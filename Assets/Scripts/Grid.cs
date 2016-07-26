using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid {

	private Dictionary<int, TileScript> tiles;

	public Grid() {
		tiles = new Dictionary<int, TileScript>();
	}

	public void add(TileScript tile) {
		tiles.Add(hashCode(tile), tile);
	}

	//Gets a tile based on hashcode
	public TileScript get(int hashCode) {
		TileScript value;
		tiles.TryGetValue(hashCode, out value);
		return value;
	}

	//Removes a tile based on object
	public void remove(TileScript tile) {
		//Should I destroy the parented object?
		//Depends on what I'll use this function for..
		remove(hashCode (tile));
	}


	//Removes a tile based on hashcode
	public void remove(int hashCode) {
		tiles.Remove (hashCode);
	}

	//A* to find path
	public void findPath(TileScript start, TileScript goal) {
		PriorityQueue<TileScript> frontier = new PriorityQueue<TileScript> ();
		frontier.Enqueue (start, 0);
		Dictionary<TileScript, TileScript> cameFrom = new Dictionary<TileScript, TileScript>();
		Dictionary<TileScript, int> cost = new Dictionary<TileScript, int>();
		cameFrom.Add (start, null);
		cost.Add (start, 0);

		TileScript current;
		while (frontier.Count != 0) {
			current = frontier.Dequeue();
			if (current == goal) {
				break;
			}

			foreach (TileScript neighbor in getNeighbors(current)) {
				int temp;
				cost.TryGetValue (current, out temp);
				int newCost =  temp + 1;
				int value;
				int priority;
				cost.TryGetValue (neighbor, out value);
				if (cost.ContainsKey(neighbor) != true || newCost < value) {
					cost.Add(neighbor, value);
					priority = newCost + heuristic(goal, neighbor);
					frontier.Enqueue (neighbor, priority);
					cameFrom.Add(neighbor, current);
				}
			}
		}
	}

	//Manhattan distance
	static public int heuristic(TileScript tileScriptA, TileScript tileScriptB) {
		return Mathf.Abs(tileScriptA.coord.x - tileScriptB.coord.x) + Mathf.Abs(tileScriptA.coord.y - tileScriptB.coord.y);
	}


	//Update me
	public TileScript[] getNeighbors(TileScript tile) {
		TileScript tileScript = tile.GetComponent<TileScript> ();
		TileScript[] neighbors = new TileScript[6];

		neighbors[0] = get(hashCode(tileScript.coord.x, tileScript.coord.y + 1));
		neighbors[1] = get(hashCode(tileScript.coord.x + 1, tileScript.coord.y + 1));
		neighbors[2] = get(hashCode(tileScript.coord.x + 1, tileScript.coord.y));
		neighbors[3] = get(hashCode(tileScript.coord.x, tileScript.coord.y - 1));
		neighbors[4] = get(hashCode(tileScript.coord.x - 1, tileScript.coord.y - 1));
		neighbors[5] = get(hashCode(tileScript.coord.x -1, tileScript.coord.y));

		return neighbors;
	}

	public int hashCode(int x, int y) {
		int hash = 17;
		hash = ((hash + x) << 5) - (hash + x);
		hash = ((hash + y) << 5) - (hash + y);
		return hash;
	}

	private int hashCode(TileScript tile) {
		Coordinate coord = tile.coord;
		return hashCode (coord.x, coord.y);
	}
		
}

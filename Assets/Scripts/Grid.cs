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

	//Gets a tile based on hashcode
	public TileScript get(Coordinate coord) {
		return get (hashCode (coord));
	}

	//Gets a tile based on hashcode
	public TileScript get(int x, int y) {
		return get (hashCode (x, y));
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
		
	public void calculateNeighbors() {
		foreach (TileScript tile in tiles.Values) {
			tile.getNeighbors ();
		}
	}

	public Dictionary<TileScript, TileScript> test(int moveSpeed, TileScript tempTile) {
		Queue<Helper> frontier = new Queue<Helper> ();
		Dictionary<TileScript, TileScript> cameFrom = new Dictionary<TileScript, TileScript>();
		Helper tempHelper = new Helper (moveSpeed, tempTile);
		frontier.Enqueue (tempHelper);
		cameFrom.Add (tempTile, null);
		while (frontier.Count != 0) {
			tempHelper = frontier.Dequeue ();
			if (tempHelper.steps > 0) {
				foreach (TileScript neighbor in tempHelper.tileScript.neighbors) {
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

	//Manhattan distance
	public int heuristic(TileScript tileScriptA, TileScript tileScriptB) {
		return Mathf.Abs(tileScriptA.coord.x - tileScriptB.coord.x) + Mathf.Abs(tileScriptA.coord.y - tileScriptB.coord.y);
	}
		


	public int hashCode(int x, int y) {
		int hash = 17;
		hash = ((hash + x) << 5) - (hash + x);
		hash = ((hash + y) << 5) - (hash + y);
		return hash;
	}

	private int hashCode(TileScript tile) {
		return hashCode(tile.coord);
	}

	private int hashCode(Coordinate coord) {
		return hashCode (coord.x, coord.y);
	}
		
}

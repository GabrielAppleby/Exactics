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
	public GameObject get(int x, int y) {
		return get (hashCode (x, y));
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
		return hashCode(tile.GetComponent<FakeTransformComponent>().position);
	}

	private int hashCode(Vector2 fakePosition) {
		return hashCode ((int) fakePosition.x, (int) fakePosition.y);
	}
		
}

using UnityEngine;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	public int movement;
	public bool waterWalk;
	public bool stoneWalk;
	public bool dirtWalk;
	public GameObject currentTile;
	public Dictionary<GameObject, GameObject> camefrom;
}

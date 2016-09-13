using UnityEngine;
using System.Collections.Generic;

public class MovementComponent : MonoBehaviour {
	public int movement;
	public int currentMovement;
	public bool waterWalk;
	public bool stoneWalk;
	public bool dirtWalk;
	public GameObject currentTile;
	public Dictionary<GameObject, GameObject> camefrom;
}

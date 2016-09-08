using UnityEngine;

public class MoveHelper : MonoBehaviour {
	public GameObject entity;
	public int numMoves;

	public MoveHelper(int numMoves, GameObject entity) {
		this.entity = entity;
		this.numMoves = numMoves;
	}

}

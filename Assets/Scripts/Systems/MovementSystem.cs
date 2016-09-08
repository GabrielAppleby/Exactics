using UnityEngine;
using System.Collections.Generic;


//I think in the future this class will be helpful
//For abstracting inputs into intentions
//For now its mostly just annoying
public class MovementSystem : MonoBehaviour {

	void OnEnable()
	{
		InputSystem.makeMove += makeMove;
	}


	void OnDisable()
	{
		InputSystem.makeMove -= makeMove;
	}

	private void calculateMove(GameObject entity) {
		entity.GetComponent<Movement> ().camefrom = getAvailableMoves(entity);

	}

	private Dictionary<GameObject, GameObject> getAvailableMoves(GameObject entity) {
		Movement moveComponent = entity.GetComponent<Movement>();
		GameObject currentTile = entity.GetComponent<CurrentTile>().currentTile;
		int numMoves = moveComponent.movement;
		Queue<MoveHelper> frontier = new Queue<MoveHelper> ();
		Dictionary<GameObject, GameObject> cameFrom = new Dictionary<GameObject, GameObject> ();
		MoveHelper tempHelper = new MoveHelper (numMoves, currentTile);
		frontier.Enqueue (tempHelper);
		cameFrom.Add (currentTile, null);
		while (frontier.Count != 0) {
			tempHelper = frontier.Dequeue ();
			if (tempHelper.numMoves > 0) {
				foreach (GameObject neighbor in tempHelper.entity.GetComponent<FakeTransform>().neighbors) {
					if (neighbor != null) {
						if (cameFrom.ContainsKey (neighbor) == false) {
							frontier.Enqueue (new MoveHelper (tempHelper.numMoves - 1, neighbor));
							//neighbor.changeColor (Color.blue);
							cameFrom.Add (neighbor, tempHelper.entity);
						}
					}
				}
			}
		}
		return cameFrom;
	}

	private void makeMove(GameObject entityToMove, GameObject entityWithLocation) {
		entityToMove.GetComponent<FakeTransform>().position = entityWithLocation.GetComponent<FakeTransform>().position;
		entityToMove.GetComponent<Transform>().position = entityWithLocation.GetComponent<Transform>().position;

	}

	/*public int heuristic(en tileScriptA, TileScript tileScriptB) {
		return Mathf.Abs(tileScriptA.coord.x - tileScriptB.coord.x) + Mathf.Abs(tileScriptA.coord.y - tileScriptB.coord.y);
	}*/
}

using UnityEngine;
using System.Collections.Generic;


//I think in the future this class will be helpful
//For abstracting inputs into intentions
//For now its mostly just annoying
using System.Collections;


public class MovementSystem : MonoBehaviour {

	void OnEnable()
	{
		InputSystem.calculateMove += calculateMove;
		InputSystem.makeMove += makeMove;
	}


	void OnDisable()
	{
		InputSystem.calculateMove += calculateMove;
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
							cameFrom.Add (neighbor, tempHelper.entity);
						}
					}
				}
			}
		}
		return cameFrom;
	}

	private void makeMove(GameObject entityToMove, GameObject entityWithLocation) {
		Debug.Log (entityToMove.transform.position);
		Dictionary<GameObject, GameObject> cameFrom = getAvailableMoves(entityToMove);
		Debug.Log (entityWithLocation.transform.position);
		if (cameFrom.ContainsKey (entityWithLocation)) {
			List<GameObject> path = new List<GameObject> ();
			GameObject current = entityWithLocation;
			path.Add (current);
			while (current != entityToMove.GetComponent<CurrentTile>().currentTile) {
				cameFrom.TryGetValue (current, out current);
				path.Add (current);
			}
			StartCoroutine(moveRawr(entityToMove, entityWithLocation, path));
		}
	}

	IEnumerator moveTest (Transform transform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f/time;
		while (i < 1.0) {
			i += Time.deltaTime * rate;
			transform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

	IEnumerator moveRawr (GameObject entityToMove, GameObject entityWithLocation, List<GameObject> path) {
		for (int i = path.Count-1; i > -1; i--) {
			entityToMove.GetComponent<CurrentTile>().currentTile = entityWithLocation;
			yield return StartCoroutine(moveTest(entityToMove.transform, entityToMove.transform.position, path[i].transform.position, 1));;
		}
	}
	

}

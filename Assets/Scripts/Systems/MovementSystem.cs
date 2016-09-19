using UnityEngine;
using System.Collections.Generic;



using System.Collections;


public class MovementSystem : MonoBehaviour {

	public delegate void MovementFinished();
	public static event MovementFinished movementFinished;

	void OnEnable()
	{
		GameSystem.movementCalculationRequested += calculateMove;
		GameSystem.moveRequested += makeMove;
		GameSystem.restRequested += resetMove;
	}


	void OnDisable()
	{
		GameSystem.movementCalculationRequested += calculateMove;
		GameSystem.restRequested += resetMove;
	}
		

	private void resetMove(GameObject unit) 
	{
		MovementComponent movementComponent = unit.GetComponent<MovementComponent> ();
		movementComponent.currentMovement = movementComponent.movement;
	}

	private void calculateMove(GameObject entity) {
		entity.GetComponent<MovementComponent> ().camefrom = getAvailableMoves(entity);

	}

	private Dictionary<GameObject, GameObject> getAvailableMoves(GameObject entity) {
		MovementComponent moveComponent = entity.GetComponent<MovementComponent>();
		GameObject currentTile = moveComponent.currentTile;
		int numMoves = moveComponent.currentMovement;
		int newCost;
		int iFuckingHateCSharp;
		Queue<MoveHelper> frontier = new Queue<MoveHelper> ();
		Dictionary<GameObject, GameObject> cameFrom = new Dictionary<GameObject, GameObject> ();
		Dictionary<GameObject, int> costSoFar = new Dictionary<GameObject, int> ();
		MoveHelper tempHelper = new MoveHelper (numMoves, currentTile);
		frontier.Enqueue (tempHelper);
		costSoFar.Add (currentTile, 0);
		cameFrom.Add (currentTile, null);
		while (frontier.Count != 0) {
			tempHelper = frontier.Dequeue ();
			if (tempHelper.numMoves > 0) {
				foreach (GameObject neighbor in tempHelper.entity.GetComponent<TerrainInfoComponent>().neighbors) {
					if (neighbor != null) {
						costSoFar.TryGetValue (tempHelper.entity, out newCost);
						costSoFar.TryGetValue (neighbor, out iFuckingHateCSharp);
						newCost += 1;
						if ((cameFrom.ContainsKey (neighbor) == false) || (newCost < iFuckingHateCSharp)) {
							TerrainInfoComponent neighborInfo = neighbor.GetComponent<TerrainInfoComponent> ();
							if (neighborInfo.terrainType == Constants.TerrainTypes.Dirt) {
								if (moveComponent.dirtWalk == false) {
									continue;
								}
							} else if (neighborInfo.terrainType == Constants.TerrainTypes.Water) {
								if (moveComponent.waterWalk == false) {
									continue;
								}
							} else if (neighborInfo.terrainType == Constants.TerrainTypes.Stone) {
								if (moveComponent.stoneWalk == false) {
									continue;
								}
							}
							frontier.Enqueue (new MoveHelper (tempHelper.numMoves - 1, neighbor));
							costSoFar.Add (neighbor, newCost);
							cameFrom.Add (neighbor, tempHelper.entity);
						}
					}
				}
			}
		}
		return cameFrom;
	}

	private void makeMove(GameObject entityToMove, GameObject entityWithLocation) {
		Dictionary<GameObject, GameObject> cameFrom = getAvailableMoves(entityToMove);
		if (cameFrom.ContainsKey (entityWithLocation)) {
			List<GameObject> path = new List<GameObject> ();
			GameObject current = entityWithLocation;
			path.Add (current);
			while (current != entityToMove.GetComponent<MovementComponent> ().currentTile) {
				cameFrom.TryGetValue (current, out current);
				path.Add (current);
			}
			StartCoroutine (moveRawr (entityToMove, entityWithLocation, path));
		} else {
			if (movementFinished != null) {
				movementFinished ();
			}

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
		MovementComponent movementComponent = entityToMove.GetComponent<MovementComponent> ();
		for (int i = path.Count-1; i > -1; i--) {
			movementComponent.currentTile.GetComponent<TerrainInfoComponent>().unit = null;
			movementComponent.currentTile = path[i];
			path [i].GetComponent<TerrainInfoComponent> ().unit = entityToMove;

			yield return StartCoroutine(moveTest(entityToMove.transform, entityToMove.transform.position, path[i].transform.position, 1));;
		}
		movementComponent.currentMovement = movementComponent.currentMovement - (path.Count - 1);
		movementFinished ();
	}
	

}

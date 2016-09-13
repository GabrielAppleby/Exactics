using UnityEngine;
using System.Collections;

public class CombatSystem : MonoBehaviour {

	public delegate void AttackFinished(bool success);
	public static event AttackFinished attackFinished;

	private void OnEnable()
	{
		GameSystem.attackRequested += handleAttackRequested;
	}

	private void OnDisable()
	{
		GameSystem.attackRequested += handleAttackRequested;
	}

	private void handleAttackRequested(GameObject attacking, GameObject defending) {
		TeamComponent defendingTeamComponent = defending.GetComponent<TeamComponent> ();
		if ((defendingTeamComponent != null) && (attacking.GetComponent<TeamComponent> ().team == defending.GetComponent<TeamComponent> ().team)) {
			attackFinished (false);
			return;
		}
		GameObject[] neighboringTiles = attacking.GetComponent<MovementComponent> ().currentTile.GetComponent<TerrainInfoComponent> ().neighbors;
		foreach (GameObject tile in neighboringTiles) {
			if (defending == tile.GetComponent<TerrainInfoComponent> ().unit) {
				attack(attacking, defending);
			}
		}
	}

	private void attack(GameObject attacking, GameObject defending) {
		Debug.Log ("Insert an equation for attacking here");
		attackFinished (true);
	}
}

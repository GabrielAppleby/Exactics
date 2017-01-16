using Entitas;
using UnityEngine;
using System.Collections.Generic;

public sealed class GameEndSystem : ISetPool, IReactiveSystem {


	public TriggerOnEvent trigger { get { return CoreMatcher.GameEnd.OnEntityAdded(); } }

	Pool _pool;

	public void SetPool(Pool pool) {
		_pool = pool;
	}

	public void Execute(List<Entity> entities) {
		Entity gameEndEntity = entities.SingleEntity();
		if (gameEndEntity.isGameEnd) {
			Debug.Log ("Game end test");
		}
		//End the game
	}
}

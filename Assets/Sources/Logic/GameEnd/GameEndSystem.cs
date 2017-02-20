using System.Collections.Generic;

using UnityEngine;

using Entitas;


public sealed class GameEndSystem : ReactiveSystem<GameEntity> {

	public GameEndSystem(Contexts contexts) : base(contexts.game) {}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> gameContext) {
		return gameContext.CreateCollector(GameMatcher.GameEnd, GroupEvent.Added);
	}

	protected override bool Filter(GameEntity entity) {
		return true;
	}

	protected override void Execute(List<GameEntity> entities) {
		GameEntity gameEndEntity = entities.SingleEntity();
		if (gameEndEntity.isGameEnd) {
			Debug.Log ("Game end test");
		}
		//End the game
	}
}

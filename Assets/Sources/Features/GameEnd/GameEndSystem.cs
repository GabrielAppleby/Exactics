using Entitas;
using UnityEngine;
using System.Collections.Generic;

public sealed class GameEndSystem : ReactiveSystem {

	public GameEndSystem(Contexts contexts) : base(contexts.game) {}

	protected override Collector GetTrigger(Context context) {
		return context.CreateCollector(GameMatcher.GameEnd, GroupEvent.Added);
	}

	protected override bool Filter(Entity entity) {
		return true;
	}

	protected override void Execute(List<Entity> entities) {
		Entity gameEndEntity = entities.SingleEntity();
		if (gameEndEntity.isGameEnd) {
			Debug.Log ("Game end test");
		}
		//End the game
	}
}

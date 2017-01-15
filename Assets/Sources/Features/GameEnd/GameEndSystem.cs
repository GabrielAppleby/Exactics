using Entitas;
using UnityEngine;
using System.Collections.Generic;

public sealed class GameEndSystem : ReactiveSystem {


	public GameEndSystem(Context context) : base(context) {

    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(CoreMatcher.GameEnd);
    }

    protected override bool Filter(Entity entity) {
        // TODO Entitas 0.36.0 Migration
        // ensure was: 
        // exclude was: 

        return true;
    }

	Context _pool;

	public void SetPool(Context Context) {
		_pool = Context;
	}

	protected override void Execute(List<Entity> entities) {
		Entity gameEndEntity = entities.SingleEntity();
		if (gameEndEntity.isGameEnd) {
			Debug.Log ("Game end test");
		}
		//End the game
	}
}

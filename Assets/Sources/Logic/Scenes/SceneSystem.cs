using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Entitas;

public sealed class SceneSystem : ReactiveSystem<GameEntity> {

	public SceneSystem(Contexts contexts) : base(contexts.game) {}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.Scene, GroupEvent.Added);
	}

	protected override bool Filter(GameEntity gameEntity) {
		return true;
	}
		
	protected override void Execute(List<GameEntity> entities) {
		SceneManager.LoadScene (entities.SingleEntity ().scene.sceneName);
	}
}

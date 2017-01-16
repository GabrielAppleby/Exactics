using Entitas;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public sealed class SceneSystem : ReactiveSystem {

	public SceneSystem(Contexts contexts) : base(contexts.game) {}

	protected override Collector GetTrigger(Context context) {
		return context.CreateCollector(GameMatcher.Scene, GroupEvent.Added);
	}

	protected override bool Filter(Entity entity) {
		return true;
	}
		
	protected override void Execute(List<Entity> entities) {
		SceneManager.LoadScene (entities.SingleEntity ().scene.sceneName);
	}
		

}

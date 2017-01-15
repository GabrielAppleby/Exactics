using Entitas;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public sealed class SceneSystem : ReactiveSystem {

	Context _pool;

	public SceneSystem(Context context) : base(context) {

    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(MenuMatcher.Scene);
    }

    protected override bool Filter(Entity entity) {
        // TODO Entitas 0.36.0 Migration
        // ensure was: 
        // exclude was: 

        return true;
    }

	public void SetPool(Context Context) {
		_pool = Context;
	}

	protected override void Execute(List<Entity> entities) {
		SceneManager.LoadScene (entities.SingleEntity ().scene.sceneName);
	}
		

}

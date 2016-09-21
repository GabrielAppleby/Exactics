using Entitas;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public sealed class SceneSystem : ISetPool, IReactiveSystem {
	Pool _pool;

	public TriggerOnEvent trigger { get { return SceneMatcher.Scene.OnEntityAdded (); } }

	public void SetPool(Pool pool) {
		_pool = pool;
	}

	public void Execute(List<Entity> entities) {
		SceneManager.LoadScene (entities.SingleEntity ().scene.sceneName);
	}
		

}

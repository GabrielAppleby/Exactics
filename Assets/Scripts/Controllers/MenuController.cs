using Entitas;
using UnityEngine;

public class MenuController : MonoBehaviour {

	Systems _systems;
	Contexts _pools;

	void Start() {
		_pools = Contexts.sharedInstance;
		if (_pools.allPools [0] == null) {
			_pools.SetAllPools ();
		}
		// Manually add entity indices.
		// It's planned to generate this in future versions of Entitas
		//Contexts.AddEntityIndices();

		_systems = createSystems(_pools);
		_systems.Initialize();
	}

	void Update() {
		_systems.Execute();
		_systems.Cleanup();
	}

	void OnDestroy() {
		_systems.TearDown();
		_systems.DeactivateReactiveSystems ();
		foreach (Context Context in _pools.allPools) {
			Context.Reset ();
		}
	}

	protected Systems createSystems(Contexts Contexts) {
		return new Feature ("Systems");
			//.Add (Contexts.menu.CreateSystem (new SceneSystem ())); Gabe made me do it
	}
}
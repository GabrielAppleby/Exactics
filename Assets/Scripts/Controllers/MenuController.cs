using Entitas;
using UnityEngine;

public class MenuController : MonoBehaviour {

	Systems _systems;
	Pools _pools;

	void Start() {
		_pools = Pools.sharedInstance;
		if (_pools.allPools [0] == null) {
			_pools.SetAllPools ();
		}
		// Manually add entity indices.
		// It's planned to generate this in future versions of Entitas
		//pools.AddEntityIndices();

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
		foreach (Pool pool in _pools.allPools) {
			pool.Reset ();
		}
	}

	protected Systems createSystems(Pools pools) {
		return new Feature ("Systems")
			.Add (pools.menu.CreateSystem (new SceneSystem ()));
	}
}
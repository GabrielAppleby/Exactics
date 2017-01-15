using Entitas;
using UnityEngine;

public class FightController : MonoBehaviour {

	Systems _systems;
	Contexts _pools;

	void Start() {

		_pools = Contexts.sharedInstance;
		if (_pools.allPools [0] == null) {
			_pools.SetAllPools ();
		}

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

	Systems createSystems(Contexts Contexts) {
		return new Feature ("Systems");
			//.Add (Contexts.menu.CreateSystem (new CreateGameMapSystem ())); Gabe made me do it
	}
}
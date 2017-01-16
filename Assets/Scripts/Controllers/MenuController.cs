using Entitas;
using UnityEngine;

public class MenuController : MonoBehaviour {

	Systems _systems;
	Contexts _contexts;

	void Start() {
		_contexts = Contexts.sharedInstance;
		if (_contexts.allContexts [0] == null) {
			_contexts.SetAllContexts ();
		}
		// Manually add entity indices.
		// It's planned to generate this in future versions of Entitas
		//pools.AddEntityIndices();

		_systems = createSystems(_contexts);
		_systems.Initialize();
	}

	void Update() {
		_systems.Execute();
		_systems.Cleanup();
	}

	void OnDestroy() {
		_systems.TearDown();
		_systems.DeactivateReactiveSystems ();
		foreach (Context pool in _contexts.allContexts) {
			pool.Reset ();
		}
	}

	protected Systems createSystems(Contexts pools) {
		return new Feature ("Systems")
			.Add (new SceneSystem (pools));
	}
}
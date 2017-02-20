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
		/*foreach (Context context in _contexts.allContexts) {
			context.Reset ();
		}*/
	}

	protected virtual Systems createSystems(Contexts contexts) {
		Systems systems = new Feature("Systems")
			.Add (new SceneSystem (contexts))
			.Add (new TeamSaveSystem (contexts));
		return systems;
	}
}
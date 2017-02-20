using Entitas;
using UnityEngine;

public class FightController : MonoBehaviour {

	Systems _systems;
	Contexts _contexts;

	void Start() {

		_contexts = Contexts.sharedInstance;
		if (_contexts.allContexts [0] == null) {
			_contexts.SetAllContexts ();
		}

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
		foreach (IContext context in _contexts.allContexts) {
			context.Reset ();
		}
	}

	Systems createSystems(Contexts contexts) {
		return new Feature("Systems")
			.Add (new CreateGameMapSystem (contexts));
	}
}
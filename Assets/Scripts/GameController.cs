using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	Systems _systems;

	void Start() {
		Pools.sharedInstance.pool = Pools.CreatePool ();
		_systems = createSystems(Pools.sharedInstance.pool);
		_systems.Initialize();
	}

	void Update() {
		_systems.Execute();
	}

	Systems createSystems(Pool pool) {
		return new Feature ("Systems").Add (Pools.sharedInstance.pool.CreateSystem(new GameMapSystem()));
	}
}
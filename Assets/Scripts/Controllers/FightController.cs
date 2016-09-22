using Entitas;
using UnityEngine;

public class FightController : MonoBehaviour {

	Systems _systems;

	void Start() {

		Pools pools = Pools.sharedInstance;
		pools.SetAllPools();
	

		_systems = createSystems(pools);
		_systems.Initialize();
	}

	void Update() {
		_systems.Execute();
		_systems.Cleanup();
	}

	void OnDestroy() {
		_systems.TearDown();
	}

	Systems createSystems(Pools pools) {
		return new Feature ("Systems")
			.Add (pools.scene.CreateSystem (new CreateGameMapSystem ()));
	}
}
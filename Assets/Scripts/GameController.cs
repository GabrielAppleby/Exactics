﻿using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

	Systems _systems;

	void Start() {

		Pools pools = Pools.sharedInstance;
		pools.SetAllPools();

		// Manually add entity indices.
		// It's planned to generate this in future versions of Entitas
		pools.AddEntityIndices();

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
		return new Feature("Systems")
			.Add(pools.core.CreateSystem(new CreateGameMapSystem()))
			.Add(pools.scene.CreateSystem(new SceneSystem()))
			.Add(pools.input.CreateSystem(new InputSystem()));
	}
}
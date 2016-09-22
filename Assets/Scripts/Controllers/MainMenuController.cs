﻿using Entitas;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	Systems _systems;
	Pools _pools;

	void Start() {

		_pools = Pools.sharedInstance;
		_pools.SetAllPools();

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
			Debug.Log ("test");
			pool.Reset ();
		}
	}

	Systems createSystems(Pools pools) {
		return new Feature ("Systems")
			.Add (pools.scene.CreateSystem (new SceneSystem ()));
	}
}
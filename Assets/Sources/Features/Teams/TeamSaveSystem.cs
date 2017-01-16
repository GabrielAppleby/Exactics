/*using Entitas;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public sealed class TeamSaveSystem : ISetPool, IReactiveSystem {

	Pool _pool;

	//public TriggerOnEvent trigger { get { return MenuMatcher.SaveTeam.OnEntityAdded (); } }

	public void SetPool(Pool pool) {
		_pool = pool;
	}

	public void Execute(List<Entity> entities) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + , FileMode.Open);


	}
}*/
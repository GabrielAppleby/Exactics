using Entitas;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public sealed class TeamLoadSystem : ISetPool, IInitializeSystem {

	Pool _pool;

	public void SetPool(Pool pool) {
		_pool = pool;
	}

	public void Initialize() {
		if (Directory.Exists (Application.persistentDataPath)) {
			foreach (string fileName in Directory.GetFiles(Application.persistentDataPath)) {
				if (fileName.StartsWith("Team")) {
					BinaryFormatter bf = new BinaryFormatter();
					FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
					TeamMenuComponent tmc = (TeamMenuComponent)bf.Deserialize (file);
					_pool.CreateEntity ()
						.AddTeamMenu (tmc.number, tmc.name);
				}
			}
		}

	}
}
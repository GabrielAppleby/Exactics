using Entitas;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public sealed class TeamLoadSystem : IInitializeSystem {

	Context _pool;

	public void SetPool(Context Context) {
		_pool = Context;
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
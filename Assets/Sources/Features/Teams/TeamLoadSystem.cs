using Entitas;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public sealed class TeamLoadSystem : IInitializeSystem {

	Context _context;

	public TeamLoadSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		if (Directory.Exists (Application.persistentDataPath)) {
			foreach (string fileName in Directory.GetFiles(Application.persistentDataPath)) {
				if (fileName.StartsWith("Team")) {
					BinaryFormatter bf = new BinaryFormatter();
					FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
					TeamMenuComponent tmc = (TeamMenuComponent)bf.Deserialize (file);
					_context.CreateEntity ()
						.AddTeamMenu (tmc.number, tmc.name);
				}
			}
		}

	}
}
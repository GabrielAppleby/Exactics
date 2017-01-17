using Entitas;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using Entitas.Serialization.Blueprints;

public sealed class TeamLoadSystem : IInitializeSystem {

	Context _context;

	public TeamLoadSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		if (Directory.Exists (Application.persistentDataPath)) {
			BinaryFormatter bf;
			Blueprint team;
			foreach (string fileName in Directory.GetFiles(Application.persistentDataPath)) {
				if (fileName.StartsWith("Team")) {
					bf = new BinaryFormatter();
					using (var file = File.Open(Application.persistentDataPath + fileName, FileMode.Open)) {
						team = (Blueprint)bf.Deserialize (file);
						_context.CreateEntity ().ApplyBlueprint(team);
					}
				}
			}
		}

	}
}
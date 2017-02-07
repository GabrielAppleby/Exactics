using Entitas;
using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using Entitas.Serialization.Blueprints;
using System.Runtime.Serialization.Formatters.Binary;

public sealed class TeamLoadSystem : IInitializeSystem {

	Context _context;

	public TeamLoadSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		string[] files;
		string path;

		// We'll do something better in the future, but this is easy for now.
		string[] tempDirectories = new string[]{ "TeamOne", "TeamTwo", "TeamThree", "TeamFour", "TeamFive" };
		string teamString = "Team";
		Entity entity;

		foreach (var folder in tempDirectories) {
			path = Application.persistentDataPath  + folder;
			if (Directory.Exists (path)) {
				files = Directory.GetFiles(path, teamString);
				if (files.Length != 0) {
					string fileText = File.ReadAllText (files [0]);
					var entitySave = JsonUtility.FromJson<EntitySave> (fileText);
					var componentTypes = Contexts.sharedInstance.game.contextInfo.componentTypes;
					entity = _context.CreateEntity();

					Dictionary<System.Type, int> idDictionary = new Dictionary<System.Type, int>();
					for (int i = 0; i < componentTypes.Length; i++) {
						idDictionary[componentTypes[i]] = i;
					}

					for (int j = 0; j < entitySave.components.Count; j++) {
						var compId = idDictionary[entitySave.components[j].GetType()];
						entity.AddComponent(compId, entitySave.components[j]);
					}
				}
			}
		}
	}
}
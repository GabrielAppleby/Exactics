using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

using Entitas;

public sealed class TeamLoadSystem : IInitializeSystem {

	GameContext _gameContext;

	public TeamLoadSystem(Contexts contexts) {
		_gameContext = contexts.game;
	}

	public void Initialize() {
		// The names of all the files in our team directory
		string[] fileNames;
		// The path to our team directory
		string path;

		// List of the folder names where we will be storing team information
		// We'll do something better in the future, but this is easy for now.
		string[] folderNames = new string[]{ "TeamOne", "TeamTwo", "TeamThree", "TeamFour", "TeamFive" };

		// The filename we are looking for is called team
		string fileName = "Team";

		foreach (String folderName in folderNames) {
			// The path where we should find the file we are looking for
			path = Application.persistentDataPath  + folderName;
			// If that directory does exist
			if (Directory.Exists (path)) {
				// Grab the file
				fileNames = Directory.GetFiles(path, fileName);
				// If we successfully grabbed the file
				if (fileNames.Length != 0) {
					// Put all of the text into a string
					string fileText = File.ReadAllText (fileNames [0]);
					// Convert that string from JSON to an entity save
					EntitySave entitySave = JsonUtility.FromJson<EntitySave> (fileText);
					// Create the entity we are going to attach all the info to
					GameEntity entity = _gameContext.CreateEntity();

					// Because where a component is added to an entity's component
					// array matters we have to grab the current Type[] of this context
					// and use it find the appropriate indexing.
					Type[] componentTypes = _gameContext.contextInfo.componentTypes;
					Dictionary<System.Type, int> indexDictionary = new Dictionary<System.Type, int>();
					for (int i = 0; i < componentTypes.Length; i++) {
						indexDictionary[componentTypes[i]] = i;
					}

					int componentIndex;
					// Now we are free to add the components to the entity.
					for (int j = 0; j < entitySave.components.Count; j++) {
						componentIndex = indexDictionary[entitySave.components[j].GetType()];
						entity.AddComponent(componentIndex, entitySave.components[j]);
					}
				}
			}
		}
	}
}
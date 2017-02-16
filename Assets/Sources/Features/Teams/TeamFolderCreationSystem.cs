using Entitas;
using System;
using System.IO;
using UnityEngine;

public sealed class TeamFolderCreationSystem : IInitializeSystem {

	public TeamFolderCreationSystem(Contexts contexts) {}

	public void Initialize() {
		// List of the folder names where we will be storing team information
		// We'll do something better in the future, but this is easy for now.
		string[] folderNames = new string[]{ "TeamOne", "TeamTwo", "TeamThree", "TeamFour", "TeamFive" };

		foreach (string folderName in folderNames) {
			// Attempts to create the directory.
			// Does nothing if directory already exists.
			Directory.CreateDirectory (Application.persistentDataPath + folderName);
		}
	}
}
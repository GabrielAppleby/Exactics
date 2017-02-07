using Entitas;
using System;
using System.IO;
using UnityEngine;

public sealed class TeamFolderCreationSystem : IInitializeSystem {

	public TeamFolderCreationSystem(Contexts contexts) {}

	public void Initialize() {
		// We'll do something better in the future, but this is easy for now.
		string[] tempDirectories = new string[]{ "TeamOne", "TeamTwo", "TeamThree", "TeamFour", "TeamFive" };

		foreach (var fileName in tempDirectories) {
			// Does nothing if directory already exists.
			Directory.CreateDirectory (Application.persistentDataPath + fileName);
		}
	}
}
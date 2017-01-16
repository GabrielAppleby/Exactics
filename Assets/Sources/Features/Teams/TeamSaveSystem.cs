using Entitas;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public sealed class TeamSaveSystem : ReactiveSystem {

	Context _context;

	public TeamSaveSystem(Contexts contexts) : base(contexts.game) {
		_context = contexts.game;
	}

	protected override Collector GetTrigger(Context context) {
		return _context.CreateCollector(GameMatcher.TeamMenu, GroupEvent.Added);
	}

	protected override bool Filter(Entity entity) {
		return true;
	}

	protected override void Execute(List<Entity> entities) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath,  FileMode.Open);
	}
}
using Entitas;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Entitas.Serialization.Blueprints;

public sealed class TeamSaveSystem : ReactiveSystem {

	Context _context;

	public TeamSaveSystem(Contexts contexts) : base(contexts.game) {
		_context = contexts.game;
	}

	protected override Collector GetTrigger(Context context) {
		return context.CreateCollector(GameMatcher.TeamCharacters, GroupEvent.Added);
	}

	protected override bool Filter(Entity entity) {
		return true;
	}

	protected override void Execute(List<Entity> entities) {
		// There will only ever be one entity with this component added
		// per game tick.
		Entity entity = entities[0];

		EntitySave es = new EntitySave();
		es.contextName = _context.contextInfo.name;

		foreach (int i in entity.GetComponentIndices()){
			es.components.Add(entity.GetComponent(i));
		}
			
		File.WriteAllText (Application.persistentDataPath + entity.isSaveDirectory, JsonUtility.ToJson (es));
	}
}
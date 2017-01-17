using Entitas;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Entitas.Serialization.Blueprints;

public sealed class TeamSaveSystem : ReactiveSystem {

	public TeamSaveSystem(Contexts contexts) : base(contexts.game) {}

	protected override Collector GetTrigger(Context context) {
		return context.CreateCollector(GameMatcher.TeamCharacters, GroupEvent.Added);
	}

	protected override bool Filter(Entity entity) {
		return true;
	}

	protected override void Execute(List<Entity> entities) {
		BinaryFormatter bf = new BinaryFormatter ();
		foreach (var entity in entities) {
			//using (var file = File.Open (Application.persistentDataPath + entity.id.id, FileMode.Open)) {
				//bf.Serialize (file, ?);
			//}
		}
	}
}
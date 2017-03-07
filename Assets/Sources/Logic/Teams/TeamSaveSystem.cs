using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

using Entitas;

public sealed class TeamSaveSystem : ReactiveSystem<GameEntity> {

	GameContext _gameContext;

	public TeamSaveSystem(Contexts contexts) : base(contexts.game) {
		_gameContext = contexts.game;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.TeamCharacters, GroupEvent.Added);
	}

	protected override bool Filter(GameEntity entity) {
		return true;
	}

	protected override void Execute(List<GameEntity> entities) {
		// There will only ever be one entity with this component added
		// per game tick.
		GameEntity entity = entities[0];

		EntitySave es = new EntitySave();
		es.contextName = _gameContext.contextInfo.name;

		foreach (int i in entity.GetComponentIndices()){
			es.components.Add(entity.GetComponent(i));
		}
			
		File.WriteAllText (Application.persistentDataPath + entity.isSaveDirectory, JsonUtility.ToJson (es));
	}
}
using System.Collections.Generic;
using Entitas;

public static class EntityIndexContextExtensions {

	public const string IdKey = "Id";

	public static void AddEntityIndices(this Contexts contexts) {
		var idIndex = new EntityIndex<string>(
			contexts.game.GetGroup(GameMatcher.Id),
			(e, c) => {
				var idComponent = c as IdComponent;
				return idComponent.id;
			}
		);

		contexts.game.AddEntityIndex(IdKey, idIndex);
	}

	public static HashSet<Entity> GetEntitiesWithId(this Context context, string id) {
		var index = (EntityIndex<string>)context.GetEntityIndex(IdKey);
		return index.GetEntities(id);
	}
}

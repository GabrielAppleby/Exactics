using System.Collections.Generic;
using Entitas;
using UnityEngine;

public static class EntityIndexPoolExtensions {


	public static void AddEntityIndices(this Contexts Contexts) {
		EntityIndex<string> positionIndex = new EntityIndex<string>(
			Contexts.core.GetGroup(Matcher.AnyOf(CoreMatcher.FakePosition, TilesMatcher.FakePosition)),
			(e, c) => {
				FakePositionComponent fakePositionComponent = c as FakePositionComponent;
					return fakePositionComponent != null
					? fakePositionComponent.x + "," + fakePositionComponent.y
						: e.fakePosition.x + "," + e.fakePosition.y;
			}
		);

		Contexts.core.AddEntityIndex(CoreComponentIds.Position.ToString(), positionIndex);
	}

	public static HashSet<Entity> GetEntitiesWithPosition(this Context Context, float x, float y) {
		var index = (EntityIndex<string>)Context.GetEntityIndex(CoreComponentIds.Position.ToString());
		return index.GetEntities(x + "," + y);
	}
}
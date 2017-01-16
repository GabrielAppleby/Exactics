/*using System.Collections.Generic;
using Entitas;
using UnityEngine;

public static class EntityIndexPoolExtensions {


	public static void AddEntityIndices(this Pools pools) {
		EntityIndex<string> positionIndex = new EntityIndex<string>(
			pools.core.GetGroup(Matcher.AnyOf(CoreMatcher.FakePosition, TilesMatcher.FakePosition)),
			(e, c) => {
				FakePositionComponent fakePositionComponent = c as FakePositionComponent;
					return fakePositionComponent != null
					? fakePositionComponent.x + "," + fakePositionComponent.y
						: e.fakePosition.x + "," + e.fakePosition.y;
			}
		);

		pools.core.AddEntityIndex(CoreComponentIds.Position.ToString(), positionIndex);
	}

	public static HashSet<Entity> GetEntitiesWithPosition(this Pool pool, float x, float y) {
		var index = (EntityIndex<string>)pool.GetEntityIndex(CoreComponentIds.Position.ToString());
		return index.GetEntities(x + "," + y);
	}
}*/
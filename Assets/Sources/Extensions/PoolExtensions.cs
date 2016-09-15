using System.Collections.Generic;
using Entitas;
using UnityEngine;

public static class PoolExtensions {


	public static void AddEntityIndices(this Pools pools) {
		var positionIndex = new EntityIndex<string>(
			pools.core.GetGroup(CoreMatcher.Position),
			(e, c) => {
				var positionComponent = c as PositionComponent;
				return positionComponent != null
					? positionComponent.x + "," + positionComponent.y
						: e.position.x + "," + e.position.y;
			}
		);

		pools.core.AddEntityIndex(CoreComponentIds.Position.ToString(), positionIndex);
	}

	public static HashSet<Entity> GetEntitiesWithPosition(this Pool pool, float x, float y) {
		var index = (EntityIndex<string>)pool.GetEntityIndex(CoreComponentIds.Position.ToString());
		return index.GetEntities(x + "," + y);
	}
}
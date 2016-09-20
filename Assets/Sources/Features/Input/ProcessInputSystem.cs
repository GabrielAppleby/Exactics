using System.Collections.Generic;
using Entitas;
using System.Linq;

public sealed class ProcessInputSystem : ISetPools, IReactiveSystem {

	public TriggerOnEvent trigger { get { return InputMatcher.Input.OnEntityAdded(); } }

	Pools _pools;

	public void SetPools(Pools pools) {
		_pools = pools;
	}

	public void Execute(List<Entity> entities) {
		Entity inputEntity = entities.SingleEntity();
		InputComponent input = inputEntity.input;

		foreach(Entity e in _pools.core.GetEntitiesWithPosition(input.x, input.y).Where(e => e.isInteractive)) {
			//e.isDestroy = true;
		}
	}
}
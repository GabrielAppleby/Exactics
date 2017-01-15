using System.Collections.Generic;
using Entitas;
using System.Linq;

public sealed class ProcessInputSystem : ReactiveSystem {

	public ProcessInputSystem(Context context) : base(context) {

    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(InputMatcher.Input);
    }

    protected override bool Filter(Entity entity) {
        // TODO Entitas 0.36.0 Migration
        // ensure was: 
        // exclude was: 

        return true;
    }

	Contexts _pools;

	public void SetPools(Contexts Contexts) {
		_pools = Contexts;
	}

	protected override void Execute(List<Entity> entities) {
		Entity inputEntity = entities.SingleEntity();
		InputComponent input = inputEntity.input;

		foreach(Entity e in _pools.core.GetEntitiesWithPosition(input.x, input.y).Where(e => e.isInteractive)) {
			//e.isDestroy = true;
		}
	}
}
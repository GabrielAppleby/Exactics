using System.Collections.Generic;
using Entitas;
using System.Linq;

public sealed class ProcessInputSystem : ReactiveSystem {

	Contexts _contexts;

	public ProcessInputSystem(Contexts contexts) : base(contexts.game) {
		_contexts = contexts;
	}

	protected override Collector GetTrigger(Context context) {
		return _contexts.input.CreateCollector(InputMatcher.Input, GroupEvent.Added);
	}

	protected override bool Filter(Entity entity) {
		return true;
	}

	protected override void Execute(List<Entity> entities) {
		Entity inputEntity = entities.SingleEntity();
		InputComponent input = inputEntity.input;

		//foreach(Entity e in _contexts.game.GetEntitiesWithPosition(input.x, input.y).Where(e => e.isInteractive)) {
			//e.isDestroy = true;
		//}
	}
}
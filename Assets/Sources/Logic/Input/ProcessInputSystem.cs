using System.Collections.Generic;
using System.Linq;

using Entitas;

public sealed class ProcessInputSystem : ReactiveSystem<InputEntity> {

	Contexts _contexts;

	public ProcessInputSystem(Contexts contexts) : base(contexts.input) {
		_contexts = contexts;
	}

	protected override Collector<InputEntity> GetTrigger(IContext<InputEntity> gameContext) {
		return _contexts.input.CreateCollector(InputMatcher.Input, GroupEvent.Added);
	}

	protected override bool Filter(InputEntity entity) {
		return true;
	}

	protected override void Execute(List<InputEntity> entities) {
		InputEntity inputEntity = entities.SingleEntity();
		InputComponent input = inputEntity.input;

		//foreach(Entity e in _contexts.game.GetEntitiesWithPosition(input.x, input.y).Where(e => e.isInteractive)) {
			//e.isDestroy = true;
		//}
	}
}
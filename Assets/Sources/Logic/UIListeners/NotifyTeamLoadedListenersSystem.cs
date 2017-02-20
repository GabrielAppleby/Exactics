using Entitas;
using System.Collections.Generic;

public class NotifyTeamLoadedListenersSystem : ReactiveSystem<GameEntity>
{
	GameContext _gameContext;
	IGroup<GameEntity> _listeners;

	public NotifyTeamLoadedListenersSystem(Contexts contexts) : base(contexts.game) {
		_gameContext = contexts.game;
		_listeners = _gameContext.GetGroup (GameMatcher.TeamCharacters);
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.TeamCharacters, GroupEvent.Added);
	}

	protected override bool Filter(GameEntity entity) {
		return true;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in _listeners.GetEntities()) {
			entity.teamLoadedListener.listener.TeamLoaded (entity);
		}
	}
}
using System.Collections.Generic;

using Entitas;

public class NotifyTeamLoadedSystem : ReactiveSystem<GameEntity>
{
	GameContext _gameContext;
	IGroup<GameEntity> _listeners;


	public NotifyTeamLoadedSystem(Contexts contexts) : base(contexts.game) {
		_gameContext = contexts.game;
		_listeners = _gameContext.GetGroup(GameMatcher.TeamLoadedListener);
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.TeamCharacters, GroupEvent.Added);
	}

	protected override bool Filter(GameEntity entity) {
		return true;
	}
		
	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity loadedEntity in entities) {
			foreach (GameEntity listenerEntity in _listeners.GetEntities()) {
				listenerEntity.teamLoadedListener.listener.TeamLoaded(loadedEntity);
			}
		}
	}
}
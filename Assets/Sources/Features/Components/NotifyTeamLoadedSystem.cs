using Entitas;
using System.Collections.Generic;

public class NotifyTeamLoadedSystem : ReactiveSystem
{
	Context _context;
	Group listeners;

	public NotifyTeamLoadedSystem(Contexts contexts) : base(contexts.game) {
		_context = contexts.game;
		listeners = _context.GetGroup(GameMatcher.TeamLoadedListener);
	}

	protected override Collector GetTrigger(Context context) {
		return context.CreateCollector(GameMatcher.TeamCharacters, GroupEvent.Added);
	}

	protected override bool Filter(Entity entity) {
		return true;
	}
		
	protected override void Execute(List<Entity> entities)
	{
		foreach (Entity loadedEntity in entities) {
			foreach (Entity listenerEntity in listeners.GetEntities()) {
				listenerEntity.teamLoadedListener.listener.TeamLoaded(loadedEntity);
			}
		}
	}
}
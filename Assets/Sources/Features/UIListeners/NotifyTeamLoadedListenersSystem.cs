using Entitas;
using System.Collections.Generic;

public class NotifyTeamLoadedListenersSystem : ReactiveSystem
{
	Context _context;
	Group _listeners;

	public NotifyTeamLoadedListenersSystem(Contexts contexts) : base(contexts.game) {
		_context = contexts.game;
		_listeners = _context.GetGroup (GameMatcher.TeamMenu);
	}

	protected override Collector GetTrigger(Context context) {
		return context.CreateCollector(GameMatcher.TeamMenu, GroupEvent.Added);
	}

	protected override bool Filter(Entity entity) {
		return true;
	}

	protected override void Execute(List<Entity> entities)
	{
		foreach (Entity entity in _listeners.GetEntities()) {
			//entity.teamLoadedListener.listener.TeamLoaded ();
		}
	}




}
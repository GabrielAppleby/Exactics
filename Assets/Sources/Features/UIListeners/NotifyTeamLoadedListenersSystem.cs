using Entitas;
using System.Collections.Generic;

public class NotifyTeamLoadedListenersSystem : ReactiveSystem
{
	Context _pool;
	Group _listeners;

	public NotifyTeamLoadedListenersSystem(Context context) : base(context) {

    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(MenuMatcher.TeamMenu);
    }

    protected override bool Filter(Entity entity) {
        // TODO Entitas 0.36.0 Migration
        // ensure was: 
        // exclude was: 

        return true;
    }

	public void SetPool(Context Context){
		_pool = Context;
		_listeners = _pool.GetGroup (MenuMatcher.TeamMenu);
	}

	protected override void Execute(List<Entity> entities)
	{
		foreach (Entity entity in _listeners.GetEntities()) {
			//entity.teamLoadedListener.listener.TeamLoaded ();
		}
	}




}
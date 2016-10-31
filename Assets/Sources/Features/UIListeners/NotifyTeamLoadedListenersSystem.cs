using Entitas;
using System.Collections.Generic;

public class NotifyTeamLoadedListenersSystem : IReactiveSystem, ISetPool
{
	Pool _pool;
	Group _listeners;

	public TriggerOnEvent trigger { get { return MenuMatcher.TeamMenu.OnEntityAdded ();}}

	public void SetPool(Pool pool){
		_pool = pool;
		_listeners = _pool.GetGroup (MenuMatcher.TeamMenu);
	}

	public void Execute(List<Entity> entities)
	{
		foreach (Entity entity in _listeners.GetEntities()) {
			entity.teamLoadedListener.listener.TeamLoaded ();
		}
	}




}
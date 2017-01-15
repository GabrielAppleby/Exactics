using UnityEngine;
using Entitas;
using System;

public class EntityLink : MonoBehaviour {

	public Entity entity { get { return _entity; } }
	public Context Context { get { return _pool; } }

	Entity _entity;
	Context _pool;

	public void Link(Entity entity, Context Context) {
		if(_entity != null) {
			throw new Exception("EntityLink is already linked to " + _entity + "!");
		}

		_entity = entity;
		_pool = Context;
		_entity.Retain(this);
	}

	public void Unlink() {
		if(_entity == null) {
			throw new Exception("EntityLink is already unlinked!");
		}

		_entity.Release(this);
		_entity = null;
		_pool = null;
	}
}

public static class EntityLinkExtension {

	public static EntityLink GetEntityLink(this GameObject gameObject) {
		return gameObject.GetComponent<EntityLink>();
	}

	public static EntityLink Link(this GameObject gameObject, Entity entity, Context Context) {
		var link = gameObject.GetEntityLink();
		if(link == null) {
			link = gameObject.AddComponent<EntityLink>();
		}

		link.Link(entity, Context);
		return link;
	}

	public static void Unlink(this GameObject gameObject) {
		gameObject.GetEntityLink().Unlink();
	}
}
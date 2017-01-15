using Entitas;
using UnityEngine;

public sealed class InputSystem : IExecuteSystem, ICleanupSystem {

	Context _pool;
	Group _inputs;

	public void SetPool(Context Context) {
		_pool = Context;
		_inputs = Context.GetGroup(InputMatcher.Input);
	}

	public void Execute() {
		bool input = Input.GetMouseButtonDown(0);
		if(input) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
			if (hit.collider != null) {
				Vector3 pos = hit.collider.transform.position;
				_pool.CreateEntity ()
				.AddInput (pos.x, pos.y);
			}
		}
	}

	public void Cleanup() {
		foreach(Entity e in _inputs.GetEntities()) {
			_pool.DestroyEntity(e);
		}
	}
}
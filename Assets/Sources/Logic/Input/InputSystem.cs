using UnityEngine;

using Entitas;

public sealed class InputSystem : IExecuteSystem, ICleanupSystem {

	InputContext _context;
	IGroup<InputEntity> _inputs;


	public InputSystem(Contexts contexts) {
		_context = contexts.input;
		_inputs = _context.GetGroup(InputMatcher.Input);
	}
		

	public void Execute() {
		bool input = Input.GetMouseButtonDown(0);
		if(input) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
			if (hit.collider != null) {
				Vector3 pos = hit.collider.transform.position;
				_context.CreateEntity ()
					.AddInput (pos.x, pos.y);
			}
		}
	}

	public void Cleanup() {
		foreach(InputEntity e in _inputs.GetEntities()) {
			_context.DestroyEntity(e);
		}
	}
}
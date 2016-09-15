using UnityEngine;
using Entitas;
using System.Collections.Generic;

public class GameMapSystem : IInitializeSystem, ISetPool {
	Pool _pool;
	//Group _gameBoardElements;

	public void SetPool(Pool pool) {
		_pool = pool;
		//_gameBoardElements = _pool.GetGroup(Matcher.AllOf(Matcher.GameBoardElement, Matcher.Position));
	}

	public void Initialize() {
		/*//Create Map image
		GameObject map = (GameObject) Object.Instantiate(Resources.Load<GameObject>("DebugNew"));
		//Create entities
		bool impassable;
		Transform mapTransform = map.GetComponent<Transform> ();
		foreach (Transform child in mapTransform) {
			if (child.name != "Terrain") {
				if (child.name == "Stone") {
					impassable = true;
				} else {
					impassable = false;
				}
				foreach (Transform nestedChild in child) {
					_pool.CreateEntity ()
						.IsGameMapElement (true)
						.IsInteractive (true)
						.IsImpassable (impassable);
				}
			}
		}
*/
	}




}

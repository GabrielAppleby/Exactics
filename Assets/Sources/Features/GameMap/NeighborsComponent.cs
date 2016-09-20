using UnityEngine;

using Entitas;

[Tiles]
public class NeighborsComponent : IComponent {
	public Entity[] neighbors;
}
using UnityEngine;
using Entitas;
using Entitas.CodeGenerator;

[SingleEntity]
public class GameMapComponent : IComponent {
	public Entity[,] grid;
}

using Entitas;
using Entitas.CodeGenerator;

[Game, SingleEntity]
public class GameMapComponent : IComponent {
	public int columns;
	public int rows;
}

using Entitas;
using Entitas.CodeGenerator;

[Core, SingleEntity]
public class GameMapComponent : IComponent {
	public int columns;
	public int rows;
}
using Entitas;
using Entitas.CodeGenerator.Api;

[Game, Unique]
public class GameMapComponent : IComponent {
	public int columns;
	public int rows;
}
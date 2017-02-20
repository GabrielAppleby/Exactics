using Entitas;
using Entitas.CodeGenerator.Api;

[Game, Unique]
public class SceneComponent : IComponent {
	public string sceneName;
}
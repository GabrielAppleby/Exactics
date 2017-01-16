using UnityEngine;
using Entitas.CodeGenerator;
using Entitas;

[Game, SingleEntity]
public class SceneComponent : IComponent {
	public string sceneName;
}
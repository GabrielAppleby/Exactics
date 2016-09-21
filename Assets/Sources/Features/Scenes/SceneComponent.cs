using UnityEngine;
using Entitas.CodeGenerator;
using Entitas;

[Scene, SingleEntity]
public class SceneComponent : IComponent {
	public string sceneName;
}
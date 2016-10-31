using UnityEngine;
using Entitas.CodeGenerator;
using Entitas;

[Menu, SingleEntity]
public class SceneComponent : IComponent {
	public string sceneName;
}

using Entitas;
using System;

[Menu, Serializable]
public sealed class TeamMenuComponent : IComponent {
	public int number;
	public string name;
}
using UnityEngine;

using Entitas;

[Game]
public class DefenseComponent : IComponent {
	public int defense;
	public int health;
	public int currentHealth;
	public int fortitude;
	public int resistance;
	public int evasion;
}
using System;
using System.Collections.Generic;
using Entitas;

[Serializable]
public class EntitySave
{
	public string entityName;
	public string contextName;
	public List<IComponent> components = new List<IComponent>();
}
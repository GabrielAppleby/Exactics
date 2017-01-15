/*using Entitas;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public sealed class TeamSaveSystem : ReactiveSystem {

	Context _pool;

	//public TeamSaveSystem(Contexts contexts) : base(context) {

    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(MenuMatcher.SaveTeam);
    }

    protected override bool Filter(Entity entity) {
        // TODO Entitas 0.36.0 Migration
        // ensure was: 
        // exclude was: 

        return true;
    }

	public void SetPool(Context Context) {
		_pool = Context;
	}

	protected override void Execute(List<Entity> entities) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + , FileMode.Open);


	}
}*/
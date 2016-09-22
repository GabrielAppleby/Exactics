﻿using UnityEngine;
using System.Collections;
using Entitas;

public sealed class OptionsUI : MonoBehaviour {

	Pool _pool;

	public void Start() {
		_pool = Pools.sharedInstance.scene;
	}


	public void HandleBackButtonClick() {
		_pool.CreateEntity().AddScene("MainMenu");
	}
		
}
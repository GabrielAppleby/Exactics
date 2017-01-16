﻿using UnityEngine;
using System.Collections;
using Entitas;

public sealed class TeamPickerUI : MonoBehaviour {

	Pool _pool;

	public void Start() {
		_pool = Pools.sharedInstance.menu;
	}


	public void HandleBackButtonClick() {
		_pool.CreateEntity().AddScene("MainMenu");
	}

}

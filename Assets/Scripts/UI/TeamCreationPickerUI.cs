﻿using UnityEngine;
using UnityEngine.UI;
using Entitas;

public sealed class TeamCreationPickerUI : MonoBehaviour, ITeamLoadedListener {

	Pool _pool;
	string _name;

	public void Start() {
		_name = this.name;
		_pool = Pools.sharedInstance.menu;
		_pool.CreateEntity ()
			.AddTeamLoadedListener (this);
	}


//	REDO ME LATER
//  AFTER PROTOTYPE UI WILL BE GENERATED
//  IN A SYSTEM AND THIS PROBLEM WON'T EXIST
	public void TeamLoaded(Entity entity) {
		switch (entity.teamMenu.number) {
		case 1:
			if (_name == "TeamOne") {
				this.gameObject.GetComponentInChildren<Text> ().text = entity.teamMenu.name;
			}
			break;
		case 2:
			if (_name == "TeamTwo") {
				this.gameObject.GetComponentInChildren<Text> ().text = entity.teamMenu.name;
			}
			break;
		case 3:
			if (_name == "TeamThree") {
				this.gameObject.GetComponentInChildren<Text> ().text = entity.teamMenu.name;
			}
			break;
		case 4:
			if (_name == "TeamFour") {
				this.gameObject.GetComponentInChildren<Text> ().text = entity.teamMenu.name;
			}
			break;
		case 5:
			if (_name == "TeamFive") {
				this.gameObject.GetComponentInChildren<Text> ().text = entity.teamMenu.name;
			}
			break;
		default:
			Debug.Log ("Something wrong with the Team Loaded function on line 30");
		}
			
	}

	public void HandleBackButtonClick() {
		_pool.CreateEntity().AddScene("MainMenu");
	}

	public void HandleTeamButtonClick() {
		_pool.CreateEntity().AddScene("TeamCreation");
	}

}

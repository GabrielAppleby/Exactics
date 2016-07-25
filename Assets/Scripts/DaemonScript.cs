using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DaemonScript : UnitScript {

	private const int HEALTH = 3;
	private const int STAMINA = 4;
	private const int MANA = 3;
	private const int SPEED = 3;
	private const int SPELLPOWER = 3;
	private const int DAMAGE = 4;
	private const int ACCURACY = 3;
	private const int DEFENSE = 3;
	private const int EVASION = 2;
	private const int FORTITUDE = 3;
	private const int RESISTANCE = 3;
	private const int INITIATIVE = 2;

	public override void Init() {
		base.Init (new Dictionary<string, int> () {
			{ "Health", HEALTH },
			{ "Stamina", STAMINA },
			{ "Mana", MANA },
			{ "Speed", SPEED },
			{ "Spellpower", SPELLPOWER },
			{ "Damage", DAMAGE },
			{ "Accuracy", ACCURACY },
			{ "Defense", DEFENSE },
			{ "Evasion", EVASION },
			{ "Fortitude", FORTITUDE },
			{ "Resistance", RESISTANCE },
			{ "Initiative", INITIATIVE }
		});
	}

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvianScript: UnitScript {

	private const int HEALTH = 3;
	private const int STAMINA = 3;
	private const int MANA = 3;
	private const int SPEED = 4;
	private const int SPELLPOWER = 3;
	private const int DAMAGE = 3;
	private const int ACCURACY = 3;
	private const int DEFENSE = 2;
	private const int EVASION = 3;
	private const int FORTITUDE = 2;
	private const int RESISTANCE = 3;
	private const int INITIATIVE = 3;

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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class Constants {

	public enum Races {Human, Goblin, Daemon, Fae, Tegimin, Avian};
	public enum Classes {Monk, Ninja, Sage, Champion, Templar, Inquisitor, Ranger, Skirmisher, Hunter, Spellsword, Hexblade, Shadowdancer, Shaman, Druid, Healer, arrior, Defender, Berserker, Mage, Arcanist, Summoner, Rogue, Assassin, Duelist, Claric, Mystic, Warpriest};
	public enum Stats {Health, Stamina, Mana, Speed, Spellpower, Damage, Accuracy, Defense, Evasion, Fortitude, Resistance, Initiative};

	public static Dictionary<Races, Dictionary<Stats, int>> raceStats = new Dictionary<Races, Dictionary<Stats, int>>() {
		{Races.Human, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 3},
				{Stats.Mana, 3},
				{Stats.Speed, 3},
				{Stats.Spellpower, 3},
				{Stats.Damage, 3},
				{Stats.Accuracy, 3},
				{Stats.Defense, 3},
				{Stats.Evasion, 3},
				{Stats.Fortitude, 3},
				{Stats.Resistance, 3},
				{Stats.Initiative, 3}
			}
		},
		{Races.Goblin, new Dictionary<Stats, int>() {
				{Stats.Health, 2},
				{Stats.Stamina, 3},
				{Stats.Mana, 3},
				{Stats.Speed, 3},
				{Stats.Spellpower, 3},
				{Stats.Damage, 3},
				{Stats.Accuracy, 4},
				{Stats.Defense, 2},
				{Stats.Evasion, 4},
				{Stats.Fortitude, 3},
				{Stats.Resistance, 2},
				{Stats.Initiative, 4}
			}
		},
		{Races.Daemon, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 4},
				{Stats.Mana, 3},
				{Stats.Speed, 3},
				{Stats.Spellpower, 3},
				{Stats.Damage, 4},
				{Stats.Accuracy, 3},
				{Stats.Defense, 3},
				{Stats.Evasion, 2},
				{Stats.Fortitude, 3},
				{Stats.Resistance, 3},
				{Stats.Initiative, 2}
			}
		},
		{Races.Fae, new Dictionary<Stats, int>() {
				{Stats.Health, 2},
				{Stats.Stamina, 2},
				{Stats.Mana, 4},
				{Stats.Speed, 3},
				{Stats.Spellpower, 4},
				{Stats.Damage, 3},
				{Stats.Accuracy, 3},
				{Stats.Defense, 3},
				{Stats.Evasion, 3},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 3},
				{Stats.Initiative, 3}
			}
		},
		{Races.Tegimin, new Dictionary<Stats, int>() {
				{Stats.Health, 4},
				{Stats.Stamina, 3},
				{Stats.Mana, 2},
				{Stats.Speed, 2},
				{Stats.Spellpower, 2},
				{Stats.Damage, 3},
				{Stats.Accuracy, 3},
				{Stats.Defense, 4},
				{Stats.Evasion, 2},
				{Stats.Fortitude, 4},
				{Stats.Resistance, 4},
				{Stats.Initiative, 2}
			}
		},
		{Races.Avian, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 3},
				{Stats.Mana, 3},
				{Stats.Speed, 4},
				{Stats.Spellpower, 3},
				{Stats.Damage, 3},
				{Stats.Accuracy, 3},
				{Stats.Defense, 2},
				{Stats.Evasion, 3},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 3},
				{Stats.Initiative, 3}
			}
		}


	};


	public static Dictionary<Classes, Dictionary<Stats, int>> classStats = new Dictionary<Classes, Dictionary<Stats, int>>() {
		{Classes.Monk, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Speed, 4},
				{Stats.Spellpower, 2},
				{Stats.Damage, 3},
				{Stats.Accuracy, 4},
				{Stats.Defense, 3},
				{Stats.Evasion, 4},
				{Stats.Fortitude, 4},
				{Stats.Resistance, 4},
				{Stats.Initiative, 6}
			}
		},
		{Classes.Ninja, new Dictionary<Stats, int>() {
				{Stats.Health, 2},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Speed, 5},
				{Stats.Spellpower, 2},
				{Stats.Damage, 4},
				{Stats.Accuracy, 4},
				{Stats.Defense, 2},
				{Stats.Evasion, 4},
				{Stats.Fortitude, 3},
				{Stats.Resistance, 3},
				{Stats.Initiative, 5}
			}
		},
		{Classes.Sage, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 3},
				{Stats.Mana, 0},
				{Stats.Speed, 3},
				{Stats.Spellpower, 3},
				{Stats.Damage, 2},
				{Stats.Accuracy, 3},
				{Stats.Defense, 4},
				{Stats.Evasion, 3},
				{Stats.Fortitude, 4},
				{Stats.Resistance, 4},
				{Stats.Initiative, 5}
			}
		}
	};
}

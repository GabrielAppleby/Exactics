using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class Constants {

	public enum Races {Human, Goblin, Daemon, Fae, Tegimin, Avian, None};
	public enum Classes {Monk, Ninja, Sage, Champion, Templar, Inquisitor, Ranger, Skirmisher, Archer, Spellsword, Hexblade, Shadowdancer, Shaman, Druid, Healer, Warrior, Defender, Berserker, Mage, Arcanist, Summoner, Rogue, Assassin, Duelist, Cleric, Mystic, Warpriest, None};
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
		},
		{Races.None, new Dictionary<Stats, int>() {
				{Stats.Health, 0},
				{Stats.Stamina, 0},
				{Stats.Mana, 0},
				{Stats.Speed, 0},
				{Stats.Spellpower, 0},
				{Stats.Damage, 0},
				{Stats.Accuracy, 0},
				{Stats.Defense, 0},
				{Stats.Evasion, 0},
				{Stats.Fortitude, 0},
				{Stats.Resistance, 0},
				{Stats.Initiative, 0}
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
				{Stats.Initiative, 4}
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
				{Stats.Initiative, 4}
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
				{Stats.Initiative, 3}
			}
		},
		{Classes.Champion, new Dictionary<Stats, int>() {
				{Stats.Health, 4},
				{Stats.Stamina, 3},
				{Stats.Mana, 0},
				{Stats.Speed, 2},
				{Stats.Spellpower, 2},
				{Stats.Damage, 4},
				{Stats.Accuracy, 4},
				{Stats.Defense, 4},
				{Stats.Evasion, 2},
				{Stats.Fortitude, 4},
				{Stats.Resistance, 3},
				{Stats.Initiative, 2}
			}
		},
		{Classes.Templar, new Dictionary<Stats, int>() {
				{Stats.Health, 4},
				{Stats.Stamina, 3},
				{Stats.Mana, 0},
				{Stats.Speed, 2},
				{Stats.Spellpower, 2},
				{Stats.Damage, 4},
				{Stats.Accuracy, 3},
				{Stats.Defense, 4},
				{Stats.Evasion, 2},
				{Stats.Fortitude, 4},
				{Stats.Resistance, 5},
				{Stats.Initiative, 2}
			}
		},
		{Classes.Inquisitor, new Dictionary<Stats, int>() {
				{Stats.Health, 4},
				{Stats.Stamina, 3},
				{Stats.Mana, 0},
				{Stats.Speed, 3},
				{Stats.Spellpower, 2},
				{Stats.Damage, 4},
				{Stats.Accuracy, 4},
				{Stats.Defense, 3},
				{Stats.Evasion, 3},
				{Stats.Fortitude, 3},
				{Stats.Resistance, 3},
				{Stats.Initiative, 3}
			}
		},
		{Classes.Ranger, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Speed, 3},
				{Stats.Spellpower, 0},
				{Stats.Damage, 4},
				{Stats.Accuracy, 4},
				{Stats.Defense, 3},
				{Stats.Evasion, 4},
				{Stats.Fortitude, 3},
				{Stats.Resistance, 3},
				{Stats.Initiative, 4}
			}
		},
		{Classes.Skirmisher, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 5},
				{Stats.Mana, 0},
				{Stats.Speed, 4},
				{Stats.Spellpower, 0},
				{Stats.Damage, 4},
				{Stats.Accuracy, 4},
				{Stats.Defense, 3},
				{Stats.Evasion, 4},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 2},
				{Stats.Initiative, 4}
			}
		},
		{Classes.Archer, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Speed, 3},
				{Stats.Spellpower, 0},
				{Stats.Damage, 4},
				{Stats.Accuracy, 4},
				{Stats.Defense, 2},
				{Stats.Evasion, 3},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 3},
				{Stats.Initiative, 3}
			}
		},
		{Classes.Spellsword, new Dictionary<Stats, int>() {
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
		{Classes.Hexblade, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 2},
				{Stats.Mana, 3},
				{Stats.Speed, 3},
				{Stats.Spellpower, 3},
				{Stats.Damage, 3},
				{Stats.Accuracy, 3},
				{Stats.Defense, 3},
				{Stats.Evasion, 2},
				{Stats.Fortitude, 3},
				{Stats.Resistance, 4},
				{Stats.Initiative, 3}
			}
		},
		{Classes.Shadowdancer, new Dictionary<Stats, int>() {
				{Stats.Health, 2},
				{Stats.Stamina, 3},
				{Stats.Mana, 3},
				{Stats.Speed, 4},
				{Stats.Spellpower, 2},
				{Stats.Damage, 3},
				{Stats.Accuracy, 3},
				{Stats.Defense, 2},
				{Stats.Evasion, 4},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 3},
				{Stats.Initiative, 4}
			}
		},
		{Classes.Shaman, new Dictionary<Stats, int>() {
				{Stats.Health, 2},
				{Stats.Stamina, 0},
				{Stats.Mana, 4},
				{Stats.Speed, 2},
				{Stats.Spellpower, 4},
				{Stats.Damage, 2},
				{Stats.Accuracy, 2},
				{Stats.Defense, 3},
				{Stats.Evasion, 2},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 4},
				{Stats.Initiative, 2}
			}
		},
		{Classes.Druid, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 1},
				{Stats.Mana, 2},
				{Stats.Speed, 3},
				{Stats.Spellpower, 3},
				{Stats.Damage, 3},
				{Stats.Accuracy, 2},
				{Stats.Defense, 3},
				{Stats.Evasion, 3},
				{Stats.Fortitude, 3},
				{Stats.Resistance, 3},
				{Stats.Initiative, 2}
			}
		},
		{Classes.Healer, new Dictionary<Stats, int>() {
				{Stats.Health, 2},
				{Stats.Stamina, 0},
				{Stats.Mana, 5},
				{Stats.Speed, 1},
				{Stats.Spellpower, 4},
				{Stats.Damage, 1},
				{Stats.Accuracy, 1},
				{Stats.Defense, 2},
				{Stats.Evasion, 2},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 4},
				{Stats.Initiative, 1}
			}
		},
		{Classes.Warrior, new Dictionary<Stats, int>() {
				{Stats.Health, 4},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Speed, 3},
				{Stats.Spellpower, 0},
				{Stats.Damage, 4},
				{Stats.Accuracy, 4},
				{Stats.Defense, 4},
				{Stats.Evasion, 3},
				{Stats.Fortitude, 4},
				{Stats.Resistance, 2},
				{Stats.Initiative, 3}
			}
		},
		{Classes.Defender, new Dictionary<Stats, int>() {
				{Stats.Health, 4},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Speed, 2},
				{Stats.Spellpower, 0},
				{Stats.Damage, 3},
				{Stats.Accuracy, 4},
				{Stats.Defense, 5},
				{Stats.Evasion, 1},
				{Stats.Fortitude, 5},
				{Stats.Resistance, 3},
				{Stats.Initiative, 2}
			}
		},
		{Classes.Berserker, new Dictionary<Stats, int>() {
				{Stats.Health, 5},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Speed, 3},
				{Stats.Spellpower, 0},
				{Stats.Damage, 4},
				{Stats.Accuracy, 4},
				{Stats.Defense, 3},
				{Stats.Evasion, 3},
				{Stats.Fortitude, 4},
				{Stats.Resistance, 2},
				{Stats.Initiative, 3}
			}
		},
		{Classes.Mage, new Dictionary<Stats, int>() {
				{Stats.Health, 1},
				{Stats.Stamina, 0},
				{Stats.Mana, 4},
				{Stats.Speed, 2},
				{Stats.Spellpower, 5},
				{Stats.Damage, 1},
				{Stats.Accuracy, 1},
				{Stats.Defense, 2},
				{Stats.Evasion, 2},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 4},
				{Stats.Initiative, 1}
			}
		},
		{Classes.Arcanist, new Dictionary<Stats, int>() {
				{Stats.Health, 1},
				{Stats.Stamina, 0},
				{Stats.Mana, 4},
				{Stats.Speed, 1},
				{Stats.Spellpower, 5},
				{Stats.Damage, 1},
				{Stats.Accuracy, 1},
				{Stats.Defense, 1},
				{Stats.Evasion, 2},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 5},
				{Stats.Initiative, 1}
			}
		},
		{Classes.Summoner, new Dictionary<Stats, int>() {
				{Stats.Health, 2},
				{Stats.Stamina, 1},
				{Stats.Mana, 5},
				{Stats.Speed, 3},
				{Stats.Spellpower, 4},
				{Stats.Damage, 2},
				{Stats.Accuracy, 2},
				{Stats.Defense, 2},
				{Stats.Evasion, 3},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 3},
				{Stats.Initiative, 2}
			}
		},
		{Classes.Rogue, new Dictionary<Stats, int>() {
				{Stats.Health, 2},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Speed, 4},
				{Stats.Spellpower, 0},
				{Stats.Damage, 4},
				{Stats.Accuracy, 4},
				{Stats.Defense, 2},
				{Stats.Evasion, 5},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 2},
				{Stats.Initiative, 4}
			}
		},
		{Classes.Assassin, new Dictionary<Stats, int>() {
				{Stats.Health, 2},
				{Stats.Stamina, 3},
				{Stats.Mana, 0},
				{Stats.Speed, 4},
				{Stats.Spellpower, 0},
				{Stats.Damage, 5},
				{Stats.Accuracy, 4},
				{Stats.Defense, 2},
				{Stats.Evasion, 4},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 2},
				{Stats.Initiative, 4}
			}
		},
		{Classes.Duelist, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Speed, 4},
				{Stats.Spellpower, 0},
				{Stats.Damage, 4},
				{Stats.Accuracy, 5},
				{Stats.Defense, 3},
				{Stats.Evasion, 4},
				{Stats.Fortitude, 3},
				{Stats.Resistance, 2},
				{Stats.Initiative, 5}
			}
		},
		{Classes.Cleric, new Dictionary<Stats, int>() {
				{Stats.Health, 3},
				{Stats.Stamina, 2},
				{Stats.Mana, 3},
				{Stats.Speed, 2},
				{Stats.Spellpower, 3},
				{Stats.Damage, 3},
				{Stats.Accuracy, 3},
				{Stats.Defense, 3},
				{Stats.Evasion, 2},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 3},
				{Stats.Initiative, 3}
			}
		},
		{Classes.Mystic, new Dictionary<Stats, int>() {
				{Stats.Health, 2},
				{Stats.Stamina, 1},
				{Stats.Mana, 4},
				{Stats.Speed, 2},
				{Stats.Spellpower, 4},
				{Stats.Damage, 2},
				{Stats.Accuracy, 2},
				{Stats.Defense, 2},
				{Stats.Evasion, 3},
				{Stats.Fortitude, 2},
				{Stats.Resistance, 4},
				{Stats.Initiative, 2}
			}
		},
		{Classes.Warpriest, new Dictionary<Stats, int>() {
				{Stats.Health, 4},
				{Stats.Stamina, 3},
				{Stats.Mana, 2},
				{Stats.Speed, 2},
				{Stats.Spellpower, 2},
				{Stats.Damage, 4},
				{Stats.Accuracy, 3},
				{Stats.Defense, 4},
				{Stats.Evasion, 2},
				{Stats.Fortitude, 3},
				{Stats.Resistance, 3},
				{Stats.Initiative, 3}
			}
		},
		{Classes.None, new Dictionary<Stats, int>() {
				{Stats.Health, 0},
				{Stats.Stamina, 0},
				{Stats.Mana, 0},
				{Stats.Speed, 0},
				{Stats.Spellpower, 0},
				{Stats.Damage, 0},
				{Stats.Accuracy, 0},
				{Stats.Defense, 0},
				{Stats.Evasion, 0},
				{Stats.Fortitude, 0},
				{Stats.Resistance, 0},
				{Stats.Initiative, 0}
			}
		}

	};
}

using UnityEngine;
using System.Collections.Generic;


//If these aren't needed in as many places as I think they will be
//I will move them into classes that make more sense

public static class Constants {


	public enum StatComponents {Defense, Initiative, Mana, Movement, Offense, Stamina};
	public static readonly int NUM_STAT_COMPONENTS = System.Enum.GetNames(typeof(StatComponents)).Length;
	public enum Races {Human, Goblin, Daemon, Fae, Tegimin, Avian, Dragon, Race};
	public enum Jobs {Monk, Ninja, Sage, Champion, Templar, Inquisitor, Ranger, Skirmisher, Archer, Spellsword, Hexblade, Shadowdancer, Shaman, Druid, Healer, Warrior, Defender, Berserker, Mage, Arcanist, Summoner, Rogue, Assassin, Duelist, Cleric, Mystic, Warpriest, Dragon, Class};
	public enum Stats {Expertise, Health, Stamina, Mana, Move, Spellpower, Damage, Accuracy, Defense, Evasion, Fortitude, Resistance, Initiative};

	public static Dictionary<Races, Dictionary<Stats, int>> raceStats = new Dictionary<Races, Dictionary<Stats, int>>() {
		{Races.Human, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 3},
				{Stats.Mana, 3},
				{Stats.Move, 3},
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
				{Stats.Expertise, 3},
				{Stats.Health, 2},
				{Stats.Stamina, 3},
				{Stats.Mana, 3},
				{Stats.Move, 3},
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
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 4},
				{Stats.Mana, 3},
				{Stats.Move, 3},
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
				{Stats.Expertise, 3},
				{Stats.Health, 2},
				{Stats.Stamina, 2},
				{Stats.Mana, 4},
				{Stats.Move, 3},
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
				{Stats.Expertise, 0},
				{Stats.Health, 4},
				{Stats.Stamina, 3},
				{Stats.Mana, 2},
				{Stats.Move, 2},
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
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 3},
				{Stats.Mana, 3},
				{Stats.Move, 4},
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
		{Races.Dragon, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 9},
				{Stats.Stamina, 9},
				{Stats.Mana, 9},
				{Stats.Move, 9},
				{Stats.Spellpower, 9},
				{Stats.Damage, 9},
				{Stats.Accuracy, 9},
				{Stats.Defense, 9},
				{Stats.Evasion, 9},
				{Stats.Fortitude, 9},
				{Stats.Resistance, 9},
				{Stats.Initiative, 9}
			}
		},
		{Races.Race, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 0},
				{Stats.Stamina, 0},
				{Stats.Mana, 0},
				{Stats.Move, 0},
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


	public static Dictionary<Jobs, Dictionary<Stats, int>> jobStats = new Dictionary<Jobs, Dictionary<Stats, int>>() {
		{Jobs.Monk, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Move, 4},
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
		{Jobs.Ninja, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 2},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Move, 5},
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
		{Jobs.Sage, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 3},
				{Stats.Mana, 0},
				{Stats.Move, 3},
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
		{Jobs.Champion, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 4},
				{Stats.Stamina, 3},
				{Stats.Mana, 0},
				{Stats.Move, 2},
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
		{Jobs.Templar, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 4},
				{Stats.Stamina, 3},
				{Stats.Mana, 0},
				{Stats.Move, 2},
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
		{Jobs.Inquisitor, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 4},
				{Stats.Stamina, 3},
				{Stats.Mana, 0},
				{Stats.Move, 3},
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
		{Jobs.Ranger, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Move, 3},
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
		{Jobs.Skirmisher, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 5},
				{Stats.Mana, 0},
				{Stats.Move, 4},
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
		{Jobs.Archer, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Move, 3},
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
		{Jobs.Spellsword, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 3},
				{Stats.Mana, 3},
				{Stats.Move, 3},
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
		{Jobs.Hexblade, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 2},
				{Stats.Mana, 3},
				{Stats.Move, 3},
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
		{Jobs.Shadowdancer, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 2},
				{Stats.Stamina, 3},
				{Stats.Mana, 3},
				{Stats.Move, 4},
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
		{Jobs.Shaman, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 2},
				{Stats.Stamina, 0},
				{Stats.Mana, 4},
				{Stats.Move, 2},
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
		{Jobs.Druid, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 1},
				{Stats.Mana, 2},
				{Stats.Move, 3},
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
		{Jobs.Healer, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 2},
				{Stats.Stamina, 0},
				{Stats.Mana, 5},
				{Stats.Move, 1},
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
		{Jobs.Warrior, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 4},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Move, 3},
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
		{Jobs.Defender, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 4},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Move, 2},
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
		{Jobs.Berserker, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 5},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Move, 3},
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
		{Jobs.Mage, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 1},
				{Stats.Stamina, 0},
				{Stats.Mana, 4},
				{Stats.Move, 2},
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
		{Jobs.Arcanist, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 1},
				{Stats.Stamina, 0},
				{Stats.Mana, 4},
				{Stats.Move, 1},
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
		{Jobs.Summoner, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 2},
				{Stats.Stamina, 1},
				{Stats.Mana, 5},
				{Stats.Move, 3},
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
		{Jobs.Rogue, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 2},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Move, 4},
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
		{Jobs.Assassin, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 2},
				{Stats.Stamina, 3},
				{Stats.Mana, 0},
				{Stats.Move, 4},
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
		{Jobs.Duelist, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 4},
				{Stats.Mana, 0},
				{Stats.Move, 4},
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
		{Jobs.Cleric, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 3},
				{Stats.Stamina, 2},
				{Stats.Mana, 3},
				{Stats.Move, 2},
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
		{Jobs.Mystic, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 2},
				{Stats.Stamina, 1},
				{Stats.Mana, 4},
				{Stats.Move, 2},
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
		{Jobs.Warpriest, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 4},
				{Stats.Stamina, 3},
				{Stats.Mana, 2},
				{Stats.Move, 2},
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
		{Jobs.Dragon, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 9},
				{Stats.Stamina, 9},
				{Stats.Mana, 9},
				{Stats.Move, 9},
				{Stats.Spellpower, 9},
				{Stats.Damage, 9},
				{Stats.Accuracy, 9},
				{Stats.Defense, 9},
				{Stats.Evasion, 9},
				{Stats.Fortitude, 9},
				{Stats.Resistance, 9},
				{Stats.Initiative, 9}
			}
		},
		{Jobs.Class, new Dictionary<Stats, int>() {
				{Stats.Expertise, 3},
				{Stats.Health, 0},
				{Stats.Stamina, 0},
				{Stats.Mana, 0},
				{Stats.Move, 0},
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

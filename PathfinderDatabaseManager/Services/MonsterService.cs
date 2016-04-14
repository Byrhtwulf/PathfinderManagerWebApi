﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PathfinderDatabaseManager.Models;
using System.Diagnostics;

namespace PathfinderDatabaseManager.Services
{
    public static class MonsterService
    {
        static pathfinder_managerEntities db = new pathfinder_managerEntities();

        public static List<Monster> GetAllMonsters()
        {
            List<Monster> monsters = db.Monsters.ToList();
            return monsters;
        }

        public static List<Monster_Names> GetAllMonsterNames()
        {
            List<Monster_Names> monsterNames = db.Monster_Names.OrderBy(x => x.Name).ToList();
            return monsterNames;
        }

        public static Boolean CreateMonster(PathfinderDatabaseManager.Models.Monster newMonster){
            try
            {
                PathfinderDatabaseManager.Monster databaseMonster = new Monster();
                databaseMonster.Name = newMonster.name;
                databaseMonster.Type = newMonster.type;
                databaseMonster.Initiative = newMonster.initiative;
                databaseMonster.Senses = newMonster.senses;
                databaseMonster.Auras = newMonster.auras;
                databaseMonster.AC = newMonster.AC;
                databaseMonster.HP = newMonster.HP != "" ? int.Parse(newMonster.HP) : 0;
                databaseMonster.HP_Mods = newMonster.HPmods;
                databaseMonster.Fortitude = newMonster.fortitude != "" ? int.Parse(newMonster.fortitude) : 0;
                databaseMonster.Reflex = newMonster.reflex != "" ? int.Parse(newMonster.reflex) : 0;
                databaseMonster.Will = newMonster.will != "" ? int.Parse(newMonster.will) : 0;
                databaseMonster.Save_Mods = newMonster.saveMods;
                databaseMonster.Defenses = newMonster.defenses;
                databaseMonster.Defensive_Abilities = newMonster.defensiveAbilities;
                databaseMonster.Weaknesses = newMonster.weaknesses;
                databaseMonster.Speed = newMonster.speed;
                databaseMonster.Reach = newMonster.reach;
                databaseMonster.Base_Attack = newMonster.baseAttack;
                databaseMonster.CMB = newMonster.CMB != "" ? int.Parse(newMonster.CMB) : 0;
                databaseMonster.CMB_Mods = newMonster.CMBMods;
                databaseMonster.CMD = newMonster.CMD;
                databaseMonster.Special_Attacks = newMonster.specialAttacks;
                databaseMonster.Special_Qualities = newMonster.specialQualities;
                databaseMonster.Ability_Scores = newMonster.abilityScores;
                databaseMonster.Feats = newMonster.feats;
                databaseMonster.Skills = newMonster.skills;
                databaseMonster.Description = newMonster.description;

                databaseMonster.Monster_Additional_Notes = ConvertAdditionalNotes(newMonster.monsterAdditionalNotes);
                databaseMonster.Monster_Attack_Groups = ConvertAttacks(newMonster.attacks);

                db.Monsters.Add(databaseMonster);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        private static IList<PathfinderDatabaseManager.Monster_Additional_Notes> ConvertAdditionalNotes(IList<MonsterAdditionalNote> notes){
            List<PathfinderDatabaseManager.Monster_Additional_Notes> monsterNotes = new List<PathfinderDatabaseManager.Monster_Additional_Notes>();
            foreach (MonsterAdditionalNote note in notes)
            {
                PathfinderDatabaseManager.Monster_Additional_Notes newNote = new PathfinderDatabaseManager.Monster_Additional_Notes();
                newNote.Name = note.noteTitle;
                newNote.Notes = note.noteBody;
                monsterNotes.Add(newNote);
            }
            return monsterNotes;
        }

        private static IList<PathfinderDatabaseManager.Monster_Attack_Groups> ConvertAttacks(IList<PathfinderDatabaseManager.Models.Attack> attacks)
        {
            List<PathfinderDatabaseManager.Monster_Attack_Groups> monsterAttacks = new List<PathfinderDatabaseManager.Monster_Attack_Groups>();
            foreach (Attack attack in attacks)
            {
                PathfinderDatabaseManager.Monster_Attack_Groups group = new PathfinderDatabaseManager.Monster_Attack_Groups();
                group.Name = attack.groupName;
                List<PathfinderDatabaseManager.Monster_Attacks> groupAttacks = new List<PathfinderDatabaseManager.Monster_Attacks>();
                foreach (GroupAttack groupAttack in attack.groupAttacks)
                {
                    PathfinderDatabaseManager.Monster_Attacks newAttack = new PathfinderDatabaseManager.Monster_Attacks();
                    newAttack.Name = groupAttack.name;
                    newAttack.To_Hit = groupAttack.bonusToHit;
                    newAttack.Dice_Count = int.Parse(groupAttack.diceCount);
                    newAttack.Dice_Value = int.Parse(groupAttack.diceValue);
                    newAttack.Bonus_Damage = int.Parse(groupAttack.diceBonus);
                    newAttack.Additional_Effects = groupAttack.additionalEffects;
                    groupAttacks.Add(newAttack);

                }
                group.Monster_Attacks = groupAttacks;
                monsterAttacks.Add(group);
            }
            return monsterAttacks;
        }
        
    }
}
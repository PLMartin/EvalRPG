using EvalRpgLib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Beings
{
    public class Unit
    {
        public string Name { get; set; }
        public Dictionary<ArmorType, Armor> Equipement { get; set; }
        public StatManager StatManager { get; set; }
        public Weapon Weapon { get; set; }
        public List<Stuff> Bag { get; set; }
        public List<Skill> Skills { get; set; }
        public int Level { get; set; }

        public Unit(
            string name,
            StatManager statManager = null,
            Dictionary<ArmorType, Armor> equipement = null,
            Weapon weapon = null)
        {
            Name = name;
            Equipement = equipement ?? new Dictionary<ArmorType, Armor>();
            StatManager = statManager ?? new StatManager(this, StatHelper.GetDefaultAttributes());
            Weapon = weapon;

            Bag = new List<Stuff>();
            Skills = new List<Skill>();
            Level = 1;
        }

        public void UpdateStats()
        {
            StatManager.Update();
        }

        public int GetCurrentStat(StatisticsEnum stat)
        {
            return StatManager.GetCurrentStatistic(stat);
        }

        public int GetCurrentAttribute(AttributeEnum attr)
        {
            return StatManager.GetCurrentAttribute(attr);
        }

        public void UseSkill(Skill skill, Unit target)
        {
            skill.Cast(target);
        }

        public bool Attack(Unit target)
        {
            if(Weapon != null)
            {
                int damage = GetCurrentStat(Weapon.IsMagic ? StatisticsEnum.MagicalDamange : StatisticsEnum.PhysicalDamage);
                target.TakeDamage(damage, Weapon.IsMagic, this);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Inflige des dégâts à l'unité
        /// </summary>
        /// <param name="amount">Quantité de dégâts</param>
        /// <param name="isMagic">Vrai si cela vient d'une attaque magique</param>
        /// <param name="caster">Unité à l'origine de l'attaque</param>
        /// <returns>La quantité de dégâts effectivement encaissée</returns>
        public int TakeDamage(int amount, bool isMagic, Unit caster)
        {
            amount -= GetCurrentStat( isMagic ? StatisticsEnum.MagicalResistance : StatisticsEnum.PhysicalResistance );

            if (amount > 0)
            {
                StatManager.CurrentStatistics[StatisticsEnum.Health] -= amount;
                return amount;
            }
            return 0;
        }

    }
}

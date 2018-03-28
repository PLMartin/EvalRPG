using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Beings
{
    public class Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public Func<Unit, bool> Ability { get; set; }
        public Unit Caster { get; set; }
        public StatisticsEnum StatisticReference { get; set; }
        public AttributeEnum AttributeReference { get; set; }
        public int BasePower { get; set; }

        public Skill(Unit caster)
        {
            Caster = caster;
        }

        /// <summary>
        /// Utilisation de cette capacité
        /// </summary>
        /// <param name="target">Cible de la capacité</param>
        /// <returns>Vrai en cas de succès, sinon faux</returns>
        public bool Cast(Unit target)
        {
            // est-ce qu'il y a suffisement de ressource ?
            if(Cost > Caster.GetCurrentStat(StatisticReference))
            {
                return false;
            }

            // payer le coût en ressource
            Caster.StatManager.CurrentStatistics[StatisticReference] -= Cost;

            Ability(target);

            return true;
        }

        public int ComputePower()
        {
            int weaponBoost = Caster.Weapon == null ? 0 : Caster.Weapon.Damage;

            int power = Caster.GetCurrentAttribute(AttributeReference) * Caster.Level;

            return weaponBoost + BasePower + power;
        }
        
    }
}

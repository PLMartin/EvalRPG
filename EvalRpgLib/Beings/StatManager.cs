using EvalRpgLib.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvalRpgLib.Beings
{
    /// <summary>
    /// Gestionnaire de statistiques (caractéristiques et attributs) pour une unité
    /// </summary>
    public class StatManager
    {
        public Dictionary<AttributeEnum, int> BaseAttributes { get; set; }
        public Dictionary<AttributeEnum, int> CurrentAttributes { get; set; }
        public Dictionary<StatisticsEnum, Func<Unit, int>> StatisticsComputer { get; set; }
        public Dictionary<StatisticsEnum, int> BaseStatistics { get; set; }
        public Dictionary<StatisticsEnum, int> CurrentStatistics { get; set; }
        public Unit Unit { get; set; }
        
        public StatManager(Unit unit,
            Dictionary<AttributeEnum, int> baseAttributes,
            Dictionary<StatisticsEnum, Func<Unit, int>> statisticsComputer = null)
        {
            Unit = unit;
            CurrentAttributes = new Dictionary<AttributeEnum, int>();
            BaseAttributes = baseAttributes ?? new Dictionary<AttributeEnum, int>();

            BaseStatistics = new Dictionary<StatisticsEnum, int>();
            CurrentStatistics = new Dictionary<StatisticsEnum, int>();

            StatisticsComputer = statisticsComputer ?? StatHelper.GetDefaultComputer();
        }

        /// <summary>
        /// Actualisation de tous les attributs et caractéristiques
        /// </summary>
        public void Update()
        {
            UpdateAttributes();
            UpdateStatistics();
        }

        /// <summary>
        /// Actualisation de tous les attributs
        /// </summary>
        public void UpdateAttributes()
        {
            CurrentAttributes.Clear();
            
            // prise en compte des attributs de base
            foreach(var item in BaseAttributes)
            {
                CurrentAttributes.AddOrIncrement(item.Key, item.Value);
            }

            // prise en compte de tous les effets de l'équipement de l'unité
            List<Stuff> allEquipedStuff = Unit.Equipement.Select(x => (Stuff)x.Value).ToList();
            allEquipedStuff.Add(Unit.Weapon);
            foreach(var item in allEquipedStuff)
            {
                foreach (AttributEffect attributEffect in item.StatusEffects)
                {
                    CurrentAttributes.AddOrIncrement(attributEffect.Attribute, attributEffect.Value);
                }
            }
        }

        /// <summary>
        /// Actualisation de toutes les caractéristiques
        /// </summary>
        public void UpdateStatistics()
        {
            // calcul de toutes les caractéristiques de base
            BaseStatistics.Clear();
            foreach (var function in StatisticsComputer)
            {
                BaseStatistics.Add(function.Key, function.Value(Unit));
            }

            // répercution sur les caractéristiques courantes
            CurrentStatistics.Clear();
        }

        /// <summary>
        /// Récupération de la valeur d'une caractéristique
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public int GetCurrentStatistic(StatisticsEnum stat)
        {
            if (CurrentStatistics.ContainsKey(stat))
            {
                return CurrentStatistics[stat];
            }

            return 0;
        }

        public int GetCurrentAttribute(AttributeEnum attr)
        {
            if(CurrentAttributes.ContainsKey(attr))
            {
                return CurrentAttributes[attr];
            }

            return 0;
        }

    }
}

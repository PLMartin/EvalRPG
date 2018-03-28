using EvalRpgLib.Beings;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Helpers
{
    public static class StatHelper
    {
        public static Dictionary<StatisticsEnum, Func<Unit, int>> GetDefaultComputer()
        {
            Dictionary<StatisticsEnum, Func<Unit, int>> dictionary = new Dictionary<StatisticsEnum, Func<Unit, int>>();
            
            dictionary.Add(StatisticsEnum.Health, unit => FuncLinear10(unit.StatManager.CurrentAttributes[AttributeEnum.Strength], unit.Level));
            dictionary.Add(StatisticsEnum.Stamina, unit => FuncLinear10(unit.StatManager.CurrentAttributes[AttributeEnum.Agility], unit.Level));
            dictionary.Add(StatisticsEnum.Mana, unit => FuncLinear10(unit.StatManager.CurrentAttributes[AttributeEnum.Intelligence], unit.Level));

            dictionary.Add(StatisticsEnum.MagicalDamange, unit => FuncLinear2(unit.StatManager.CurrentAttributes[AttributeEnum.Intelligence], unit.Level));
            dictionary.Add(StatisticsEnum.MagicalResistance, unit => FuncLinear2(unit.StatManager.CurrentAttributes[AttributeEnum.Agility], unit.Level));
            dictionary.Add(StatisticsEnum.PhysicalDamage, unit => FuncLinear2(unit.StatManager.CurrentAttributes[AttributeEnum.Strength], unit.Level));
            dictionary.Add(StatisticsEnum.PhysicalResistance, unit => FuncLinear2(unit.StatManager.CurrentAttributes[AttributeEnum.Agility], unit.Level));
            
            return dictionary;
        }

        public static Dictionary<AttributeEnum, int> GetDefaultAttributes()
        {
            return new Dictionary<AttributeEnum, int>
            {
                { AttributeEnum.Strength, 0 },
                { AttributeEnum.Agility, 0 },
                { AttributeEnum.Intelligence, 0 },
            };
        }


        /// <summary>
        /// f(x, y) = 10x + y
        /// </summary>
        /// <param name="x">Un entier</param>
        /// <param name="y">Un autre entier</param>
        /// <returns>Un entier</returns>
        public static int FuncLinear10(int x, int y)
        {
            return 10 * x + y;
        }

        /// <summary>
        /// f(x, y) = 2x + y
        /// </summary>
        /// <param name="x">Un entier</param>
        /// <param name="y">Un autre entier</param>
        /// <returns>Un entier</returns>
        public static int FuncLinear2(int x, int y)
        {
            return 2 * x + y;
        }
    }
}

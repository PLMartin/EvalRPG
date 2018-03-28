using System;
using System.Collections.Generic;
using System.Text;
using EvalRpgLib.Beings;

namespace EvalRpgLib.Exemples
{
    public class Rat : BaseUnit
    {
        public Rat() : base("Rat", null, null)
        {
            StatManager = new StatManager(this, new Dictionary<AttributeEnum, int> {
                { AttributeEnum.Strength, 1 },
                { AttributeEnum.Agility, 3 },
                { AttributeEnum.Intelligence, 0 },
            });
        }


    }
}

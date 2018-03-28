using EvalRpgLib.Beings;
using EvalRpgLib.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Exemples
{
    public class BaseUnit : Unit, IMapContent
    {
        public MapElement Location { get; set; }

        public BaseUnit(string name, StatManager statManager, Dictionary<ArmorType, Armor> equipement, Weapon weapon = null)
            : base(name, statManager, equipement, weapon)
        { /* vide */ }


        
    }
}

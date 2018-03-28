using EvalRpgLib.Beings;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Exemples
{
    public class Hero : BaseUnit
    {
        public Hero(string name)
            : base(name, 
                   null, 
                   new Dictionary<ArmorType, Armor> {
                       {ArmorType.Chest, new BasicChest()}
                   },
                  new BasicSword())
        {

            Skills.Add(new HeavyStrike(this));
        }
    }
}

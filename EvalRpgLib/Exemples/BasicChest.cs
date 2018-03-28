using EvalRpgLib.Beings;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Exemples
{
    public class BasicChest : Armor
    {
        public BasicChest() 
            : base("Basic Chest", ArmorType.Chest, 3)
        {
            AddAttributEffects(new AttributEffect
            {
                Attribute = AttributeEnum.Strength,
                Value = 1
            });
        }
    }
}

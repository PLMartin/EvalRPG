using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Beings
{
    public class Armor : Stuff
    {
        public int Amount { get; set; }
        public ArmorType Type { get; set; }

        public Armor(string name, ArmorType type, int amount)
            :base(name)
        {
            Type = type;
            Amount = amount;
        }


    }
}

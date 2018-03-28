using EvalRpgLib.Beings;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Exemples
{
    public class BasicSword : Weapon
    {
        public BasicSword()
            : base("Iron Sword", false)
        {
            Damage = 10;
        }
    }
}

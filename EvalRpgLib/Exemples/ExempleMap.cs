using EvalRpgLib.World;
using EvalRpgLib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Exemples
{
    public class ExempleMap : Map
    {
        public void AddContent(List<BaseUnit> units)
        {
            // placement très basique, il vaudrait mieux rendre ça random

            int i = 0;
            Matrix.ForEachWithElement(e =>
            {
                e.AddContent(units[i++]);
            });
        }
    }
}

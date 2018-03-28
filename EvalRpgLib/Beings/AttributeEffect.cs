using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Beings
{
    /// <summary>
    /// Effet sur un attribut qui peut être rattaché sur une pièce d'équipement
    /// </summary>
    public class AttributEffect
    {
        public AttributeEnum Attribute { get; set; }
        public int Value { get; set; }
    }
}

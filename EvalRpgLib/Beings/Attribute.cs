using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Beings
{
    /// <summary>
    /// Représente un attribut et sa valeur (Force, Agilité, Intelligence)
    /// </summary>
    public class Attribute
    {
        public AttributeEnum Type { get; set; }
        public int Value { get; set; }
    }
}

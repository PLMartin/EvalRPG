using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.World
{

    /// <summary>
    /// Interface servant a définir ce qui est être placé dans une carte
    /// </summary>
    public interface IMapContent
    {

        /// <summary>
        /// La position dans la carte
        /// </summary>
        MapElement Location { get; set; }

    }
}

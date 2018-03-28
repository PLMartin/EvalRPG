using System;
using System.Collections.Generic;
using System.Text;
using EvalRpgLib.Beings;
using EvalRpgLib.World;

namespace EvalRpgLib.Exemples
{
    public class ExempleGame
    {
        public ExempleMap Map { get; set; }
        public List<BaseUnit> Foes { get; set; }
        public Hero Hero { get; set; }

        public ExempleGame()
        {
            string heroName = "Luc";

            Hero = new Hero(heroName);
            Hero.StatManager = new StatManager(Hero, new Dictionary<AttributeEnum, int>
            {
                { AttributeEnum.Strength, 15 },
                { AttributeEnum.Agility, 10 },
                { AttributeEnum.Intelligence, 10 },
            });

            Foes = new List<BaseUnit>();
            Foes.Add(new Rat());

            Map = new ExempleMap();
            Map.AddContent(Foes);
        }
    }
}

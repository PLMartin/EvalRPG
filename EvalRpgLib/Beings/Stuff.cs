using System.Collections.Generic;

namespace EvalRpgLib.Beings
{
    /// <summary>
    /// Objet de base pour l'équipement d'une unité (arme ou armure)
    /// </summary>
    public class Stuff
    {
        public string Name { get; set; }
        public List<AttributEffect> StatusEffects { get; set; }

        public Stuff(string name)
        {
            Name = name;
            StatusEffects = new List<AttributEffect>();
        }

        public void AddAttributEffects(AttributEffect statusEffect)
        {
            StatusEffects.Add(statusEffect);
        }
    }
}

using EvalRpgLib.Beings;

namespace EvalRpgLib.Exemples
{
    public class HeavyStrike : Skill
    {
        public HeavyStrike(Unit caster)
            : base(caster)
        {
            Name = "Heavy Strike";
            Description = "Strike a foe with all your strength. Dealing huge damage to their body and scares people around.";
            Cost = 10;
            StatisticReference = StatisticsEnum.Stamina;
            
            Ability = Effect;
        }

        private bool Effect(Unit target)
        {
            int baseDamage = ComputePower();
            target.TakeDamage(baseDamage, false, Caster);
            
            return true;
        }
    }
}

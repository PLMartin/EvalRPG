
namespace EvalRpgLib.Beings
{
    public class Weapon : Stuff
    {
        public int Damage { get; set; }
        public bool IsMagic { get; set; }

        public Weapon(string name, bool isMagic)
            : base(name)
        {
            IsMagic = isMagic;
        }
    }
}

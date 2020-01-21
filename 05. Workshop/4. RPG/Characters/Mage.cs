namespace RPG.Characters
{
    using Weapons;

    public class Mage : Character
    {
        public Mage(Weapon weapon) : base(weapon)
        {
        }

        public override string ToString()
        {
            return "Mage" + base.ToString();
        }
    }
}

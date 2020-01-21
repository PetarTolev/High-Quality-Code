namespace RPG.Characters
{
    using Weapons;

    public abstract class Character
    {
        protected Character(Weapon weapon)
        {
            this.Weapon = weapon;
        }

        public Weapon Weapon { get; set; }

        public override string ToString()
        {
            return $" wields weapon {Weapon.ToString()}";
        }
    }
}

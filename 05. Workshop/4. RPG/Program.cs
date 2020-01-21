namespace RPG
{
    using Characters;
    using System;
    using Weapons;

    public class Program
    {
        static void Main()
        {
            Warrior axeWarrior = new Warrior(new Axe());
            Warrior swordWarrior = new Warrior(new Sword());
            Mage axeMage = new Mage(new Axe());
            Mage swordMage = new Mage(new Sword());

            Console.WriteLine(axeWarrior);
            Console.WriteLine(swordMage);

            Console.WriteLine(swordWarrior);
            Console.WriteLine(axeMage);
        }
    }
}

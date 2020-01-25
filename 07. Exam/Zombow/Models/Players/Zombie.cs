namespace Zombow.Models.Players
{
    public class Zombie : Player
    {
        private const int DefaultLifePoints = 50;

        public Zombie(string name)
            : base(name, DefaultLifePoints)
        {
        }
    }
}
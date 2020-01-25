namespace Zombow.Models.Players
{
    public class MainPlayer : Player
    {
        private const string DefaultName = "Andrew";
        private const int DefaultLifePoints = 100;

        public MainPlayer()
            : base(DefaultName, DefaultLifePoints)
        {
        }
    }
}
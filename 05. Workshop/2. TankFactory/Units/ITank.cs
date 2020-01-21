namespace TankManufacturer.Units
{
    public interface ITank
    {
        string Model { get; set; }

        double Speed { get; set; }

        int AttackDamage { get; set; }
    }
}
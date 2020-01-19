namespace AirCombat.Core.Contracts
{
    using AirCombat.Entities.AirCrafts.Contracts;

    public interface IBattleOperator
    {
        string Battle(IAirCraft attacker, IAirCraft target);
    }
}
public interface IUnit
{
    bool Active { get; set; }
    bool Alive { get; set; }
    int Armor { get; set; }
    int CurrentHealth { get; set; }
    int Damage { get; set; }
    int Health { get; set; }
    bool InBattle { get; set; }
    int Initiative { get; set; }
    bool IsPlayerTeam { get; set; }
    float Speed { get; set; }
}
namespace Game04MakeEverything.Damagables
{
    public interface IDamagable
    {
        String Name { get; }
        int Atk { get; }
        int Def { get; }
        int HP { get; }
        int Gold { get; }
        int Level { get; }
        bool IsAlive { get; set; }

        int Attack(IDamagable damagable);
    }
}

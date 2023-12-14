namespace Game04MakeEverything.Items
{
    public enum Type { twoHand, oneHand, head, body, potion, material }

    public class Item
    {
        public string Name { get; }
        public string Description { get; }
        public Type Type { get; }
        public int Atk { get; }
        public int Def { get; }
        public int HP { get; }
        public int MP { get; }
        public int Cost { get; }
        public bool Equipable { get; }
        public bool IsEquipped { get; set; }
        public int ItemCount { get; set; }

        public Item(string name, string description, Type type,
            int atk, int def, int hp, int mp, int gold,
            bool equipable = true, bool equipped = false, int count = 1)
        {
            Name = name;
            Description = description;
            Type = type;
            Atk = atk;
            Def = def;
            HP = hp;
            MP = mp;
            Cost = gold;
            Equipable = equipable;
            IsEquipped = equipped;
            ItemCount = count;
        }
    }
}

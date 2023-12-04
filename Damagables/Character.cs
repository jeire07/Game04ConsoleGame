using Game04MakeEverything.Items;
using static System.Console;

namespace Game04MakeEverything.Damagables
{
    public enum Job { none, warrior, mage };  // 후기 업데이트 시 적용

    public class Character : IDamagable
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int HP { get; set; }
        public int Gold { get; set; }
        public List<Item> Inventory { get; }
        public bool IsDead { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Character(string name, string job = "인간", int level = 1,
            int atk = 10, int def = 5, int hp = 100, int gold = 1500)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            HP = hp;
            Gold = gold;
            Inventory = new List<Item>(20);
        }

        public bool IsEquipped(Item item)
        {
            return item.IsEquipped;
        }

        public void ToggleEquipStatus(int idx)
        {
            Inventory[idx].IsEquipped = !Inventory[idx].IsEquipped;
        }

        public bool IsExist(Item item)
        {
            return Inventory.Any(item => item.Name == item.Name);
        }

        public void AddItem(Item item)
        {
            if (IsExist(item) && !item.Equipable)
            {
                item.Count++;
            }
            else
            {
                Inventory.Add(item);
                item.IsEquipped = false;
            }
        }

        public void SubtractItem(Item item)
        {
            if (!IsExist(item))
            {
                WriteLine("없는 아이템입니다.");
            }
            else if (item.Count > 1)
            {
                item.Count--;
            }
            else
            {
                item.IsEquipped = false;
                Inventory.Remove(item);
            }
        }

        public int TakeDamage(int damage)
        {
            int hp = HP;
            hp -= damage;

            if (hp < 0)
            {
                return 0;
            }
            else
            {
                return hp;
            }
        }

        public int Attack(IDamagable opponent)
        {
            return 0;
        }
    }
}

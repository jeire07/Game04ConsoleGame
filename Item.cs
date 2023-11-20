﻿using static System.Console;

namespace Game04MakeEverything
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
        public int Cost { get; }
        public bool Equipable { get; }
        public bool IsEquipped { get; set; }
        public int Count { get; set; }

        public Item(string name, string description, Type type,
            int atk, int def, int hp, int gold, 
            bool equipable = true, bool equipped = false, int count = 1)
        {
            Name = name;
            Description = description;
            Type = type;
            Atk = atk;
            Def = def;
            HP = hp;
            Cost = gold;
            Equipable = equipable;
            IsEquipped = equipped;
            Count = count;
        }

        public void ItemInfo(bool withNumber = false, int idx = 0)
        {
            if(withNumber)
            {
                ForegroundColor = ConsoleColor.DarkMagenta;
                Write($"{idx.ToString("00")} ");
                ResetColor();
            }

            if (IsEquipped)
            {
                Write(" [");
                ForegroundColor = ConsoleColor.Cyan;
                Write("E");
                ResetColor();
                Write("] ");
                Write(PadRightText($"{Name}", 15));
            }
            else
            {
                Write(PadRightText($"     {Name}", 20));
            }
            //Write(Atk >= 0 ? $" | Atk +{Atk}" : $" | Atk {Atk}");
            //Write(Def >= 0 ? $" | Def +{Def}" : $" | Def {Def}");
            //Write(HP >= 0 ? $" | HP +{HP}" : $" | HP {HP}");
            Write(PadRightStat("Atk", Atk, "", 10));
            Write(PadRightStat("Def", Def, "", 10));
            Write(PadRightStat("HP", HP, "", 10));
            Write(PadRightStat("", Cost, " G", 12));
            WriteLine($" | {Description}");
        }

        public string PadRightStat(string text1, int value, string text2, int length)
        {
            string text = value >= 0 ? $" | {text1} +{value}{text2}" : $" | {text1} {value}{text2}";
            int padding = length - PrintableLength(text);
            return text.PadRight(text.Length + padding);
        }

        public string PadRightText(string text, int length)
        {
            int padding = length - PrintableLength(text);
            return text.PadRight(text.Length + padding);
        }

        public int PrintableLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2; // 한글과 같은 넓은 문자에 대해 길이를 2로 취급
                }
                else
                {
                    length += 1; // 나머지 문자에 대해 길이를 1로 취급
                }
            }

            return length;
        }
    }
}

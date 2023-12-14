using Game04MakeEverything.Damagables;
using Game04MakeEverything.Items;
using static System.Console;

namespace Game04MakeEverything.Utils
{
    class Utility
    {
        public static void ItemInfo(Item item, bool withNumber = false, int idx = 0)
        {
            if (withNumber)
            {
                ForegroundColor = ConsoleColor.DarkMagenta;
                Write($"{idx.ToString("00")} ");
                ResetColor();
            }

            if (item.IsEquipped)
            {
                Write(" [");
                ForegroundColor = ConsoleColor.Cyan;
                Write("E");
                ResetColor();
                Write("] ");
                Write(PadRightText($"{item.Name}", 15));
            }
            else
            {
                Write(PadRightText($"     {item.Name}", 20));
            }
            Write(PadRightStat("Atk", item.Atk, "", 10));
            Write(PadRightStat("Def", item.Def, "", 10));
            Write(PadRightStat("HP", item.HP, "", 10));
            Write(PadRightStat("MP", item.MP, "", 10));
            Write(PadRightStat("", item.Cost, " G", 12));
            WriteLine($" | {item.Description}");
        }

        public static int CheckValidInput(int min, int max, string description = " 원하시는 행동을 입력해주세요.")
        {
            bool parseSuccess;
            int userInput;
            do
            {
                WriteLine(description);
                Write(" ");
                parseSuccess = int.TryParse(ReadLine(), out userInput);
            } while (!parseSuccess || CheckIfValid(userInput, min, max) == false);

            return userInput;
        }

        private static bool CheckIfValid(int userInput, int min, int max)
        {
            return min <= userInput && userInput <= max ? true : false;
        }

        public static int GetSumBonusString(Character player, string propertyName)
        {
            int sum = 0;
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                if (player.Inventory[i].IsEquipped)
                {
                    // 리플렉션을 사용하여 현재 아이템의 propertyName 속성 값을 가져옵니다.
                    var propertyInfo = player.Inventory[i].GetType().GetProperty(propertyName);
                    if (propertyInfo != null)
                    {
                        // 속성 값이 int 타입이라고 가정하고 값을 가져옵니다.
                        int value = (int)propertyInfo.GetValue(player.Inventory[i], null);
                        sum += value;
                    }
                }
            }
            return sum;
        }

        public static void PrintColoredText(string text,
            ConsoleColor color = ConsoleColor.Yellow)
        {
            ForegroundColor = color;
            WriteLine(text);
            ResetColor();
        }

        public static void PrintwithColoredText(string s1, string s2, string s3 = "",
            ConsoleColor color = ConsoleColor.Cyan)
        {
            Write(s1);
            ForegroundColor = color;
            Write(s2);
            ResetColor();
            WriteLine(s3);
        }

        public static string PadRightStat(string text1, int value, string text2, int length)
        {
            string text = value >= 0 ? $" | {text1} +{value}{text2}" : $" | {text1} {value}{text2}";
            int padding = length - PrintableLength(text);
            return text.PadRight(text.Length + padding);
        }

        public static string PadRightText(string text, int length)
        {
            int padding = length - PrintableLength(text);
            return text.PadRight(text.Length + padding);
        }

        public static int PrintableLength(string str)
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
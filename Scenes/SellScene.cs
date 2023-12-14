using Game04MakeEverything.Damagables;
using Game04MakeEverything.Utils;
using static System.Console;

namespace Game04MakeEverything.Scenes
{
    class SellScene : Scene
    {
        public static SellScene Instance
        {
            get
            {
                if (instance == null)
                    instance = new SellScene();

                return instance;
            }
        }

        private static SellScene instance;
        Character _player;

        public override void EnterScene(Character character)
        {
            _player = character;

            Display();

            int input = Utility.CheckValidInput(0, _player.Inventory.Count);
            switch (input)
            {
                case 0:
                    MarketScene.Instance.EnterScene(_player);
                    break;
                default:
                    _player.Gold += (int)(_player.Inventory[input-1].Cost * 0.85f);
                    _player.SubtractItem(_player.Inventory[input-1]);
                    Instance.EnterScene(_player);
                    break;
            }
        }

        protected override void Display()
        {
            Clear();

            WriteLine();
            Utility.PrintColoredText(" 잡화점");
            WriteLine(" 해당 번호를 입력하면 1개씩 판매할 수 있습니다.");
            WriteLine();
            WriteLine(" [보유 골드]");
            Utility.PrintwithColoredText(" ", _player.Gold.ToString(), "G");
            WriteLine();
            WriteLine(" [아이템 목록]");
            int inventoryCount = _player.Inventory.Count;
            for (int i = 0; i < inventoryCount; i++)
            {
                Utility.ItemInfo(_player.Inventory[i], true);
            }

            WriteLine();
            WriteLine(" 0. 나가기");
            WriteLine();
            WriteLine(" 원하시는 행동을 입력해주세요.");
        }
    }
}

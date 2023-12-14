using Game04MakeEverything.Damagables;
using Game04MakeEverything.Items;
using Game04MakeEverything.Utils;
using static System.Console;

namespace Game04MakeEverything.Scenes
{
    class BuyScene : Scene
    {
        public static BuyScene Instance
        {
            get
            {
                if (instance == null)
                    instance = new BuyScene();

                return instance;
            }
        }

        private static BuyScene instance;
        private Character _player;
        private Character _merchant;
        private Item _items;

        public override void EnterScene(Character character)
        {
            _player = character;
            _merchant = new Character("jeire", "인간");
            MerchantInventory();

            Display();

            int input = Utility.CheckValidInput(0, _player.Inventory.Count);
            switch (input)
            {
                case 0:
                    MarketScene.Instance.EnterScene(_player);
                    break;
                default:
                    if (_player.Gold >= _merchant.Inventory[input-1].Cost)
                    {
                        _player.Gold -= _merchant.Inventory[input-1].Cost;
                        _player.AddItem(_merchant.Inventory[input-1]);
                        BuyScene.Instance.EnterScene(_player);
                    }
                    else
                    {
                        WriteLine(" Gold가 부족합니다.");
                    }
                    break;
            }
        }

        protected override void Display()
        {
            Clear();

            WriteLine();
            Utility.PrintColoredText(" 잡화점");
            WriteLine(" 해당 번호를 입력하면 1개씩 구매할 수 있습니다.");
            WriteLine();
            WriteLine(" [보유 골드]");
            Utility.PrintwithColoredText(" ", _player.Gold.ToString(), "G");
            WriteLine();
            WriteLine(" [아이템 목록]");
            int inventoryCount = _merchant.Inventory.Count;
            for (int i = 0; i < inventoryCount; i++)
            {
                Utility.ItemInfo(_merchant.Inventory[i], true, i+1);
            }

            WriteLine();
            WriteLine(" 0. 나가기");
            WriteLine();
            WriteLine(" 원하시는 행동을 입력해주세요.");
        }

        private void MerchantInventory()
        {
            _merchant.AddItem(new Item("막대기", "나무막대기입니다", Items.Type.oneHand, 1, 0, 0, 0, 20));
            _merchant.AddItem(new Item("흰 옷", "백의민족의 옷, 흰 옷입니다", Items.Type.body, 0, 5, 0, 0, 1000));
            _merchant.AddItem(new Item("똥 묻은 옷", "병에 걸릴 것 같은 똥 묻은 옷입니다", Items.Type.body, 0, 0, 0, -10, 0));
            _merchant.AddItem(new Item("종이칼", "맨주먹이 나을 것 같습니다", Items.Type.oneHand, -5, 0, 0, 0, 50));
            _merchant.AddItem(new Item("종이방패", "맨손으로 막는 게 나을 것 같습니다.", Items.Type.oneHand, 0, -5, 0, 0, 50));

            _merchant.AddItem(new Item("짱돌", "잘 다듬어져서 던지기 좋습니다", Items.Type.oneHand, 2, 0, 0, 0, 10));
            _merchant.AddItem(new Item("철광석", "불순물이 섞인 철광석입니다", Items.Type.material, 1, 0, 0, 0, 100));
            _merchant.AddItem(new Item("소다회", "각종 식물을 태운 뒤 정제한 소다회입니다", Items.Type.material, 1, 0, 0, 0, 100));
            _merchant.AddItem(new Item("소금", "각종 식물을 태운 뒤 정제한 소다회입니다", Items.Type.material, 1, 0, 0, 0, 100));
            _merchant.AddItem(new Item("올리브", "당신이 아는 그 올리브 열매입니다.", Items.Type.material, 1, 0, 0, 0, 100));
        }
    }
}

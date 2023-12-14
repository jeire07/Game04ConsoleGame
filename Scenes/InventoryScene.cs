using Game04MakeEverything.Damagables;
using Game04MakeEverything.Utils;
using static System.Console;

namespace Game04MakeEverything.Scenes
{
    class InventoryScene : Scene
    {
        public static InventoryScene Instance
        {
            get
            {
                if (instance == null)
                    instance = new InventoryScene();

                return instance;
            }
        }

        private static InventoryScene instance;
        Character _player;

        public override void EnterScene(Character character)
        {
            _player = character;

            Display();

            switch (Utility.CheckValidInput(0, 1))
            {
                case 0:
                    MainScene.Instance.EnterScene(_player);
                    break;
                case 1:
                    EquipScene.Instance.EnterScene(_player);
                    break;
            }
        }

        protected override void Display()
        {
            Clear();

            WriteLine();
            Utility.PrintColoredText(" 인벤토리");
            WriteLine(" 보유 중인 아이템을 관리할 수 있습니다.");
            WriteLine();
            WriteLine(" [아이템 목록]");

            int inventoryCount = _player.Inventory.Count;
            for (int i = 0; i < inventoryCount; i++)
            {
                Utility.ItemInfo(_player.Inventory[i]);
            }

            WriteLine();
            WriteLine(" 0. 나가기");
            WriteLine(" 1. 장착관리");
            WriteLine();
            WriteLine(" 원하시는 행동을 입력해주세요.");
        }
    }
}

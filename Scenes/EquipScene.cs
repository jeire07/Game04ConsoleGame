using Game04MakeEverything.Damagables;
using Game04MakeEverything.Utils;
using static System.Console;

namespace Game04MakeEverything.Scenes
{
    class EquipScene : Scene
    {
        public static EquipScene Instance
        {
            get
            {
                if (instance == null)
                    instance = new EquipScene();

                return instance;
            }
        }

        private static EquipScene instance;
        private Character _player;

        public override void EnterScene(Character character)
        {
            _player = character;

            Display();

            int input = Utility.CheckValidInput(0, _player.Inventory.Count);
            switch (input)
            {
                case 0:
                    InventoryScene.Instance.EnterScene(_player);
                    break;
                default:
                    _player.ToggleEquipStatus(input - 1);
                    Instance.EnterScene(_player);
                    break;
            }
        }

        protected override void Display()
        {
            Clear();

            WriteLine();
            Utility.PrintColoredText(" 인벤토리 - 장착 관리");
            WriteLine(" 아이템 장착을 관리할 수 있습니다.");
            WriteLine("");
            WriteLine(" [아이템 목록]");

            int inventoryCount = _player.Inventory.Count;
            for (int i = 0; i < inventoryCount; i++)
            {
                Utility.ItemInfo(_player.Inventory[i], true, i+1);
            }

            WriteLine();
            WriteLine(" 0. 나가기");
            WriteLine();
            WriteLine(" 원하시는 행동을 입력해주세요.");
        }
    }
}

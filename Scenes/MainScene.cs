using Game04MakeEverything.Damagables;
using Game04MakeEverything.Utils;
using static System.Console;

namespace Game04MakeEverything.Scenes
{
    class MainScene : Scene
    {
        public static MainScene Instance
        {
            get {
                if (instance == null)
                    instance = new MainScene();

                return instance; }
        }

        private static MainScene instance;
        Character _player;

        public override void EnterScene(Character character)
        {
            _player = character;

            Display();
            
            switch (Utility.CheckValidInput(1, 4))
            {
                case 1:
                    StatusScene.Instance.EnterScene(_player);
                    break;
                case 2:
                    InventoryScene.Instance.EnterScene(_player);
                    break;
                case 3:
                    MarketScene.Instance.EnterScene(_player);
                    break;
                case 4:
                    RestScene.Instance.EnterScene(_player);
                    break;
            }
        }

        protected override void Display()
        {
            Clear();

            WriteLine(" 1. 상태창");
            WriteLine(" 2. 인벤토리");
            WriteLine(" 3. 상점");
            WriteLine(" 4. 휴식");
            WriteLine();
            WriteLine(" 원하시는 행동을 입력해주세요.");

            WriteLine();
            WriteLine(" 무엇을 하시겠습니까?");
            WriteLine();
        }
    }
}

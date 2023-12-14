using Game04MakeEverything.Damagables;
using Game04MakeEverything.Utils;
using static System.Console;

namespace Game04MakeEverything.Scenes
{
    class MarketScene : Scene
    {
        public static MarketScene Instance
        {
            get
            {
                if (instance == null)
                    instance = new MarketScene();

                return instance;
            }
        }

        private static MarketScene instance;
        private Character _player;

        public override void EnterScene(Character character)
        {
            _player = character;

            Display();

            switch (Utility.CheckValidInput(0, 2))
            {
                case 0:
                    MainScene.Instance.EnterScene(_player);
                    break;
                case 1:
                    BuyScene.Instance.EnterScene(_player);
                    break;
                case 2:
                    SellScene.Instance.EnterScene(_player);
                    break;
            }
        }

        protected override void Display()
        {
            Clear();

            WriteLine();
            Utility.PrintColoredText(" 잡화점");
            WriteLine(" 아이템을 사고 팔 수 있습니다.");
            WriteLine();
            WriteLine(" [보유 골드]");
            Utility.PrintwithColoredText(" ", _player.Gold.ToString(), "G");
            WriteLine();
            WriteLine(" 1. 아이템 구매");
            WriteLine(" 2. 아이템 판매");
            WriteLine(" 0. 나가기");
            WriteLine();
            WriteLine(" 원하시는 행동을 입력해주세요.");
        }
    }
}

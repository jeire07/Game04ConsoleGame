using Game04MakeEverything.Damagables;
using Game04MakeEverything.Utils;
using static System.Console;

namespace Game04MakeEverything.Scenes
{
    class RestScene : Scene
    {
        public static RestScene Instance
        {
            get
            {
                if (instance == null)
                    instance = new RestScene();

                return instance;
            }
        }

        private static RestScene instance;
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
                    if (_player.Gold >= 500)
                    {
                        _player.HP = 100;
                        _player.Gold -= 500;
                        WriteLine("휴식을 완료했습니다.");
                    }
                    else
                    {
                        WriteLine("Gold가 부족합니다.");
                    }
                    break;
            }
        }

        protected override void Display()
        {
            Clear();

            Utility.PrintColoredText(" 휴식하기");
            Utility.PrintwithColoredText(" ", "500", " G 를 내면 체력을 회복할 수 있습니다.");
            Utility.PrintwithColoredText(" (보유 골드 : ", $"{_player.Gold}", " G)");
            WriteLine();
            WriteLine(" 1. 휴식하기");
            WriteLine(" 0. 나가기");
            WriteLine();
            WriteLine(" 원하시는 행동을 입력해주세요.");
        }
    }
}

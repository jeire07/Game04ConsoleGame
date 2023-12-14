using Game04MakeEverything.Damagables;
using static System.Console;

namespace Game04MakeEverything.Scenes
{
    class StartScene : Scene
    {
        public static StartScene Instance
        {
            get
            {
                if (instance == null)
                    instance = new StartScene();

                return instance;
            }
        }

        private static StartScene instance;
        private Character _player;

        public override void EnterScene(Character character)
        {
            _player = character;

            Display();

            _player.Name = CheckName();

            MainScene.Instance.EnterScene(_player);
        }

        protected override void Display()
        {
            Clear();

            WriteLine();
            WriteLine(" 완제품이 없는 세상에 오신 것을 환영합니다.");
            WriteLine();
        }

        private string CheckName()
        {
            bool ValidName = false;
            string userName = "jeire";

            while (!ValidName)
            {
                WriteLine(" 당신의 이름부터 만드시지요.");
                WriteLine(" 당신의 이름은 무엇입니까?");
                Write(" ");
                userName = ReadLine() ?? "jeire";
                if (userName.Length < 13)
                {
                    ValidName = true;
                }
                else
                {
                    WriteLine();
                    WriteLine(" Michelangelo도 12글자입니다");
                    WriteLine(" 길면 부르기 귀찮으니 이참에 새로 12글자 이내로 만드시지요");
                    WriteLine(" 당신의 이름은 무엇으로 하겠습니까?");
                    continue;
                }
            }
            return userName;
        }
    }
}

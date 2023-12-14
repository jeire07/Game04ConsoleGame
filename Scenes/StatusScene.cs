using Game04MakeEverything.Damagables;
using Game04MakeEverything.Utils;
using static System.Console;

namespace Game04MakeEverything.Scenes
{
    class StatusScene : Scene
    {
        public static StatusScene Instance
        {
            get
            {
                if (instance == null)
                    instance = new StatusScene();

                return instance;
            }
        }

        private static StatusScene instance;
        private Character _player;

        public override void EnterScene(Character character)
        {
            _player = character;

            Display();

            switch (Utility.CheckValidInput(0, 0))
            {
                case 0:
                    MainScene.Instance.EnterScene(_player);
                    break;
            }
        }

        protected override void Display()
        {
            Clear();

            WriteLine();
            Utility.PrintColoredText(" 상태보기");
            WriteLine(" 캐릭터의 정보를 표시합니다.");
            WriteLine();
            Utility.PrintwithColoredText(" Lv.", _player.Level.ToString("00"));
            WriteLine();
            WriteLine($" 이  름 : {_player.Name}");
            Utility.PrintwithColoredText(" 직업   : ", "무직");

            int bonusAtk = Utility.GetSumBonusString(_player, "Atk");
            int bonusDef = Utility.GetSumBonusString(_player, "Def");
            int bonusHP = Utility.GetSumBonusString(_player, "HP");
            Utility.PrintwithColoredText(" 공격력 : ", (_player.Atk + bonusAtk).ToString(), bonusAtk >= 0 ? $" (+{bonusAtk})" : $" ({bonusAtk})");
            Utility.PrintwithColoredText(" 방어력 : ", (_player.Def + bonusDef).ToString(), bonusDef >= 0 ? $" (+{bonusDef})" : $" ({bonusDef})");
            Utility.PrintwithColoredText(" 체력   : ", (_player.HP + bonusHP).ToString(), bonusHP >= 0 ? $" (+{bonusHP})" : $" ({bonusHP})");
            Utility.PrintwithColoredText(" Gold   : ", _player.Gold.ToString(), "G");
            WriteLine();
            WriteLine(" 0. 나가기");
            WriteLine();
            WriteLine(" 원하시는 행동을 입력해주세요.");
        }
    }
}

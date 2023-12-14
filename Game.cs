using Game04MakeEverything.Damagables;
using Game04MakeEverything.Items;
using Game04MakeEverything.Scenes;

namespace Game04MakeEverything
{
    public class Game
    {
        private Character _player;

        public Game()
        {
            GameDataSetting();
            MainScene.Instance.EnterScene(_player);
        }

        private void GameDataSetting()
        {
            _player = new Character("jeire", "인간");
            StartScene.Instance.EnterScene(_player);

            _player.AddItem(new Item("막대기", "나무막대기입니다", Items.Type.oneHand, 1, 0, 0, 0, 20));
            _player.AddItem(new Item("흰 옷", "백의민족의 옷, 흰 옷입니다", Items.Type.body, 0, 5, 0, 0, 1000));
            _player.AddItem(new Item("똥 묻은 옷", "병에 걸릴 것 같은 똥 묻은 옷입니다", Items.Type.body, 0, 0, 0, -10, 0));

            _player.ToggleEquipStatus(0);
        }
    }
}

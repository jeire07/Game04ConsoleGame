using Game04MakeEverything.Damagables;

namespace Game04MakeEverything.Scenes
{
    abstract class Scene
    {
        abstract public void EnterScene(Character character);
        abstract protected void Display();
    }
}

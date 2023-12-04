using Game04MakeEverything.Damagables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game04MakeEverything.Scenes
{
    abstract class Scene
    {
        abstract public void EnterScene(Character character);
        abstract protected void Display();
    }
}

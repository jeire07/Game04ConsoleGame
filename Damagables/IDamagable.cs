using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game04MakeEverything.Damagables
{
    public interface IDamagable
    {
        string Name { get; }
        int Atk { get; }
        int Def { get; }
        int HP { get; set; }
        int Gold { get; }
        int Level { get; }
        bool IsDead { get; set; }

        int Attack(IDamagable opponent);
    }
}

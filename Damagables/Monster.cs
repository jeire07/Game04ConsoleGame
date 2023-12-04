using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game04MakeEverything.Damagables
{
    public class Monster : IDamagable
    {
        public string Name => throw new NotImplementedException();

        public int Atk => throw new NotImplementedException();

        public int Def => throw new NotImplementedException();

        public int HP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Gold => throw new NotImplementedException();

        public int Level => throw new NotImplementedException();

        public bool IsDead { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Attack(IDamagable opponent)
        {
            throw new NotImplementedException();
        }
    }
}

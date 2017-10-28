using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Adapter
{
    class TurkeyClassAdapter : WildTurkey, IDuck
    {
        public void Quack()
        {
            base.Gobble();
        }

        void IDuck.Fly()
        {
            for (int i = 0; i < 5; i++)
            {
                base.Fly();
            }
        }
    }
}

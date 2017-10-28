using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Adapter
{
    public interface ITurkey
    {
        // Turckeys don't quack, they gobble
        void Gobble();
        void Fly();
    }

    public class WildTurkey : ITurkey
    {
        public void Gobble()
        {
            Console.WriteLine("Gobble gobble");
        }

        public void Fly()
        {
            Console.WriteLine("Flying short distance");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Adapter
{
    public class TestAdapter
    {
        public static void Run()
        {
            // Class Adapter
            TurkeyClassAdapter classAdapter = new TurkeyClassAdapter();
            testDuck(classAdapter);

            // Object Adapter
            WildTurkey turkey = new WildTurkey();
            TurkeyObjectAdapter objectAdapter = new TurkeyObjectAdapter(turkey);
            testDuck(objectAdapter);
        }

        static void testDuck(IDuck duck)
        {
            duck.Quack();
            duck.Fly();
        }
    }
}

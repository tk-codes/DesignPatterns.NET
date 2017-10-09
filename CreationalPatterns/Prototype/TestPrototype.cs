using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Prototype
{
    public class TestPrototype
    {
        public static void Run()
        {
            ShapeManager.LoadShapes();

            Shape clonedCircle = ShapeManager.GetShape("Circle");
            Console.WriteLine(clonedCircle);

            Shape clonedCircle2 = ShapeManager.GetShape("Circle");
            Console.WriteLine(clonedCircle2);

            Shape cloneSquare = ShapeManager.GetShape("Square");
            Console.WriteLine(cloneSquare);

            Console.ReadKey();
        }
    }
}

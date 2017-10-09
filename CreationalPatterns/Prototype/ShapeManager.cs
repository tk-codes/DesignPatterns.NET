using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Prototype
{
    class ShapeManager
    {
        private static readonly Dictionary<string, Shape> Shapes = new Dictionary<string, Shape>();

        public static void LoadShapes()
        {
            Circle circle = new Circle { Id = 1 };
            Shapes.Add(circle.Type, circle);

            Square square = new Square { Id = 2 };
            Shapes.Add(square.Type, square);
        }

        public static Shape GetShape(string key)
        {
            return Shapes[key].Clone();
        }
    }
}

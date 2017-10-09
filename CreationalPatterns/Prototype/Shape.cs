using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Prototype
{
    public abstract class Shape
    {
        public int Id { get; set; }
        public string Type { get; }

        protected Shape(string type)
        {
            Type = type;
        }

        public abstract Shape Clone();

        public override string ToString()
        {
            return "Shape: " + Id + " - " + Type + "@"+ GetHashCode();
        }
    }

    public class Circle : Shape
    {

        public Circle() : base("Circle")
        {

        }

        public override Shape Clone()
        {
            return (Shape) this.MemberwiseClone();
        }
    }

    public class Square : Shape
    {

        public Square() : base("Square")
        {

        }

        public override Shape Clone()
        {
            return (Shape) this.MemberwiseClone();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.FactoryMethod
{
    public enum PizzaType
    {
        Cheese,
        Veggie
    };

    public class Pizza
    {
        public string Name { get; set; }
        public string Dough { get; set; }

        public void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Console.WriteLine("Tossing dough..." + Dough);
        }

        public void Bake()
        {
            Console.WriteLine("Bake for 15 minutes");
        }

        public void cut()
        {
            Console.WriteLine("Cutting the pizza into 8 slices");
        }

        public void box()
        {
            Console.WriteLine("Pack the pizza in a box");
        }
    }

    // American Pizzas
    public class AmericanCheesePizza : Pizza{
        public AmericanCheesePizza()
        {
            this.Name = "American Style Cheese Pizza";
            this.Dough = "Extra thick crust dough";
        }
    }

    public class AmericanVeggiePizza : Pizza
    {
        public AmericanVeggiePizza()
        {
            this.Name = "American Vegetarian Pizza";
            this.Dough = "Extra thick crust dough";
        }
    }

    // Italian Pizzas
    public class ItalianCheesePizza : Pizza
    {
        public ItalianCheesePizza()
        {
            this.Name = "Italian Style Cheese Pizza";
            this.Dough = "Thin crust dough";
        }
    }

    public class ItalianVeggiePizza : Pizza
    {
        public ItalianVeggiePizza()
        {
            this.Name = "Italian Vegetarian Pizza";
            this.Dough = "Thin crust dough";
        }
    }

}

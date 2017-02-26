using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.AbstractFactory
{
    public enum PizzaType
    {
        Cheese,
        Veggie
    };

    public abstract class Pizza
    {
        public string Name { get; set; }
        public Dough Dough { get; set; }

        public abstract void Prepare();

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
    public class CheesePizza : Pizza{
        private string description = "Cheese Pizza";
        private PizzaIngredientFactory ingredientFactory;

        public CheesePizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
            this.Name = ingredientFactory.GetName() + " Style " + description;
        }

        public override void Prepare()
        {
            Console.WriteLine("Preparing {0}", this.Name);
            this.Dough = ingredientFactory.CreateDough();
            Console.WriteLine("Creating {0}", this.Dough.GetName());
        }
    }

    public class VeggiePizza : Pizza
    {
        private string description = "Veggie Pizza";
        private PizzaIngredientFactory ingredientFactory;

        public VeggiePizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
            this.Name = ingredientFactory.GetName() + " Style " + description;
        }

        public override void Prepare()
        {
            Console.WriteLine("Preparing {0}", this.Name);
            this.Dough = ingredientFactory.CreateDough();
            Console.WriteLine("Creating {0}", this.Dough.GetName());
        }
    }

}

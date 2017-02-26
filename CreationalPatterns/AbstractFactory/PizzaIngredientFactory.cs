using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.AbstractFactory
{
    public interface PizzaIngredientFactory
    {
        string GetName();
        Dough CreateDough();
    }

    public class AmericanPizzaIngredientFactory : PizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            return new ThickCrustDough();
        }

        public string GetName()
        {
            return "American";
        }
    }

    public class ItalianPizzaIngredientFactory : PizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            return new ThinCrustDough();
        }

        public string GetName()
        {
            return "Italian";
        }
    }
}

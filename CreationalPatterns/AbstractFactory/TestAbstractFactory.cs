using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.AbstractFactory
{
    public class TestAbstractFactory
    {
        public static void run()
        {
            PizzaStore americanStore = new AmericanPizzaStore();
            Pizza pizza = americanStore.OrderPizza(PizzaType.Veggie);
            Console.WriteLine("Esposito ordered a " + pizza.Name);
            Console.ReadLine();
        }
    }
}

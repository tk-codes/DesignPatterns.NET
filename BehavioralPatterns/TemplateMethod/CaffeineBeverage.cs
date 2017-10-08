using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.TemplateMethod
{
    public abstract class CaffeineBeverage
    {

        // Template Method
        // It serves as a template for an algorithm.
        // In this case, an algorithm for making caffeinated beverages.
        public void PrepareRecipe()
        {
            BoilWater();
            Brew(); // abstract -> handled by subclass
            PourInCup();
            AddCondiments(); // abstract --> handled by subclass
        }

        public abstract void Brew();
        public abstract void AddCondiments();

        public void BoilWater()
        {
            Console.WriteLine("Boiling water");
        }

        public void PourInCup()
        {
            Console.WriteLine("Pouring in a cup");
        }
    }

    public class Tea : CaffeineBeverage
    {
        public override void Brew()
        {
           Console.WriteLine("Steeping the tea");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Adding Lemon");
        }
    }

    public class Coffee : CaffeineBeverage
    {
        public override void Brew()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Adding Sugar and Milk");
        }
    }
}

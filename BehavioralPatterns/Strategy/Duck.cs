using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Strategy
{
    public abstract class Duck
    {
        public FlyBehavior FlyBehavior { get;  set; }
        public QuackBehavior QuackBehavior { get;  set; }

        public Duck() { }

        public abstract void Display();
        
        public void PerformFly()
        {
            // Delegate to the behavior class
            FlyBehavior.Fly();
        }

        public void PerformQuack()
        {
            QuackBehavior.DoQuack();
        }

        public void Swim()
        {
            Console.WriteLine("All ducks float, even decoys");
        }
    }

    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            base.FlyBehavior = new FlyWithWings();
            base.QuackBehavior = new Quack();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }

    public class RubberDuck : Duck
    {
        public RubberDuck()
        {
            base.QuackBehavior = new Squeak();
            base.FlyBehavior = new FlyNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a rubber duck");
        }
    }

    public class DecoyDuck : Duck
    {
        public DecoyDuck()
        {
            base.QuackBehavior = new MuteQuack();
            base.FlyBehavior = new FlyNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a decoy duck");
        }

    }
}

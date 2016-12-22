using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Strategy
{
   public interface QuackBehavior
    {
        void DoQuack();
    }

    public class Quack : QuackBehavior
    {
        // Note: Method name should be the same as class name
        public void DoQuack()
        {
            Console.WriteLine("Quack");
        }
    }

    public class MuteQuack : QuackBehavior
    {
        public void DoQuack()
        {
            Console.WriteLine("<< Silence >>");
        }
    }

    public class Squeak : QuackBehavior
    {
        public void DoQuack()
        {
            Console.WriteLine("Squeak");
        }
    }


}

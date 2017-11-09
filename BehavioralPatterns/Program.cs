using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehavioralPatterns.Mediator;
using BehavioralPatterns.Memento;

namespace BehavioralPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Caretaker.Run();
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Memento
{
    public class Caretaker
    {
        public static void Run()
        {
            IList<Memento> mementoes = new List<Memento>();

            Originator originator = new Originator();
            originator.SetState("State 1");
            originator.SetState("State 2");
            mementoes.Add(originator.Save()); // checkpoint 1
            
            originator.SetState("State 3");
            mementoes.Add(originator.Save()); // checkpoint 2

            originator.SetState("State 4");
            originator.Restore(mementoes[0]); // restore to checkpoint 1
        }
    }
}

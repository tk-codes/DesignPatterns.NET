using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Memento
{
    class Originator
    {
        private String _state;

        public void SetState(String state)
        {
            this._state = state;
            Console.WriteLine($"State is set to {state}");
        }

        public Memento Save()
        {
            Console.WriteLine($"Saving state to Memento");
            return new Memento(this._state);
        }

        public void Restore(Memento m)
        {
            this._state = m.State;
            Console.WriteLine($"State is restored from Memento: {_state}");
        }
    }
}

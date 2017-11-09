using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Memento
{
    [Serializable]
    class Memento
    {
        public string State { get; }

        public Memento(String state)
        {
            this.State = state;
        }
    }
}

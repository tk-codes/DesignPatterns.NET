using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.NullObject
{
    class NullLog : ILog
    {
        public void Write(string message)
        {
            // do nothing
        }
    }
}

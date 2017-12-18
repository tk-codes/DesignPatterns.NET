using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Bridge
{
    // Abstraction
    public interface IRemote
    {
        void PowerOn();
        void PowerOff();
        void VolumeUp();
        void VolumeDown();
    }


}

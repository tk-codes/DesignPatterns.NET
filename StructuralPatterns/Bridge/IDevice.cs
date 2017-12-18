using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Bridge
{
    public interface IDevice
    {
        void PowerOn();
        void PowerOff();
        int GetVolumen();
        void SetVolume();
    }
}

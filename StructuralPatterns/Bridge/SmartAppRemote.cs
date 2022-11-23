namespace StructuralPatterns.Bridge
{
    // Refined Abstraction
    public class SmartAppRemote : IRemote
    {
        private readonly IDevice _device;
        
        public SmartAppRemote(IDevice device)
        {
            _device = device;
        }
        
        public void PowerOn()
        {
            _device.PowerOn();
        }

        public void PowerOff()
        {
            _device.PowerOff();
        }

        public void VolumeUp()
        {
            _device.VolumeUp();
        }

        public void VolumeDown()
        {
            _device.VolumeDown();
        }
    }
}

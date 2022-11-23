namespace StructuralPatterns.Bridge
{
    // Implementor
    public interface IDevice
    {
        void PowerOn();
        void PowerOff();
        void VolumeUp();
        void VolumeDown();
    }
}

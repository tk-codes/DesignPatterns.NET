using System;

namespace StructuralPatterns.Bridge;

// Concrete Implementor
public class NormalTv : IDevice
{
    public void PowerOn()
    {
        Console.WriteLine("TV is on");
    }

    public void PowerOff()
    {
        Console.WriteLine("TV is off");
    }

    public void VolumeUp()
    {
        Console.WriteLine("TV volume is increased");
    }

    public void VolumeDown()
    {
        Console.WriteLine("TV volume is decreased");
    }
}
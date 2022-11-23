using System;

namespace StructuralPatterns.Bridge;

// Concrete Implementor
public class SmartTv : IDevice
{
    public void PowerOn()
    {
        Console.WriteLine("TV is on");
        Console.WriteLine("TV is connected to internet");
        Console.WriteLine("Open apps");
    }

    public void PowerOff()
    {
        Console.WriteLine("Close apps");
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
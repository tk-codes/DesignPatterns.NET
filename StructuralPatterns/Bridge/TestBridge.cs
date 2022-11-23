namespace StructuralPatterns.Bridge;

public static class TestBridge
{
    public static void Run()
    {
        // Abstraction-Implementation combination 1 =>  Smart TV + Physical Remote
        var smartTv = new SmartTv();
        var physicalRemote = new PhysicalRemote(smartTv);
        physicalRemote.PowerOn();
        physicalRemote.VolumeUp();
        physicalRemote.PowerOff();
        
        // Abstraction-Implementation combination 2 =>  Smart TV + Smart App Remote
        var smartAppRemote = new SmartAppRemote(smartTv);
        smartAppRemote.PowerOn();
        smartAppRemote.VolumeUp();
        smartAppRemote.PowerOff();
        
        // Abstraction-Implementation combination 3 =>  Normal TV + Physical Remote
        var normalTv = new NormalTv();
        var physicalRemote2 = new PhysicalRemote(normalTv);
        physicalRemote2.PowerOn();
        physicalRemote2.VolumeUp();
        physicalRemote2.PowerOff();
    }
}
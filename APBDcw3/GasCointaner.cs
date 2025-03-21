namespace APBDcw3;

public class GasCointaner : Container, IHazardNotifer
{
    public GasCointaner(double weightOfLoad, double height, double weightOfContener, double maxLoadWeight) : base("G", weightOfLoad, height, weightOfContener, maxLoadWeight)
    {
    }

    public void NotifyHazard()
    {
        Console.WriteLine("Alert of dangerous action in GasContainer: " + serialNumber); 
    }
    
    public override void emptyContener()
    {
        weightOfLoad = weightOfLoad* 0.05;
    }
}
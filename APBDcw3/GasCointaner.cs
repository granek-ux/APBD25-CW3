namespace APBDcw3;

public class GasCointaner : Container, IHazardNotifer
{
    public GasCointaner() : base("G")
    {
        
    }
    public void NotifyHazard(string contenerName)
    {
        Console.WriteLine("Alert of dangerous action in GasContainer: " + contenerName); 
    }
    
    public override void emptyContener()
    {
        weightOfLoad = weightOfLoad* 0.05;
    }
}
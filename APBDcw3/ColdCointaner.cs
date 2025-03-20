namespace APBDcw3;

public class ColdCointaner : Container, IHazardNotifer
{
    
    private string typeOfProduct { get; set; }
    double temperature { get; set; }

    public ColdCointaner() : base("C")
    {
        
    }

    public void NotifyHazard(string contenerName)
    {
        Console.WriteLine("Alert of dangerous action in ColdContainer: " + contenerName); 
    }

    public override void emptyContener()
    {
        weightOfLoad = weightOfLoad* 0.05;
    }
}
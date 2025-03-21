namespace APBDcw3;

public class ColdCointaner : Container, IHazardNotifer
{
    public ColdCointaner( double weightOfLoad, double height, double weightOfContener, double maxLoadWeight, string typeOfProduct, double temperature) : base("C", weightOfLoad, height, weightOfContener, maxLoadWeight)
    {
        this.typeOfProduct = typeOfProduct;
        this.temperature = temperature;
    }

    private string typeOfProduct { get; set; }
    double temperature { get; set; }
    

    public void NotifyHazard()
    {
        Console.WriteLine("Alert of dangerous action in ColdContainer: " + serialNumber); 
    }

    public override void emptyContener()
    {
        weightOfLoad = weightOfLoad* 0.05;
    }
}
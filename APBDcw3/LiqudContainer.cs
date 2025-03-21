namespace APBDcw3;

public class LiqudContainer : Container , IHazardNotifer
{
    private TypeOfLoad typeOfLoad;

    public LiqudContainer(double weightOfLoad, double height, double weightOfContener, double maxLoadWeight, TypeOfLoad typeOfLoad) : base("L", weightOfLoad, height, weightOfContener, maxLoadWeight)
    {
        this.typeOfLoad = typeOfLoad;
    }

    public override void LoadContener(int weight)
    {
        double tmpMaxLoadWeight;
        if (typeOfLoad == TypeOfLoad.Dangerous)
        {
            tmpMaxLoadWeight = maxLoadWeight/2;
        }
        else
        {
            tmpMaxLoadWeight = maxLoadWeight * 0.9;
        }

        if (weight + weightOfLoad > tmpMaxLoadWeight)
            NotifyHazard();
        
        base.LoadContener(weight);
    }

    public void NotifyHazard()
    {
        Console.WriteLine("Alert of dangerous action in LiqudContainer: " + serialNumber);
    }
}
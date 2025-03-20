namespace APBDcw3;

public class LiqudContainer : Container , IHazardNotifer
{
    private TypeOfLoad typeOfLoad;
    
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
            NotifyHazard(serialNumber);
        else
            weightOfLoad += weight;
    }

    public void NotifyHazard(string contenerName)
    {
        Console.WriteLine("Alert of dangerous action in LiqudContainer: " + contenerName);
    }
}
namespace APBDcw3;

public abstract class Container
{
    public double weightOfLoad { get; set; }

    public double height { get; set; }

    public double weightOfContener { get; set; }

    public String serialNumber { get; set; }

    public double maxLoadWeight { get; set; }

    private static int id = 0;
    
    protected Container(String typeOfCointaner, double weightOfLoad, double height, double weightOfContener, double maxLoadWeight)
    {
        this.weightOfLoad = weightOfLoad;
        this.height = height;
        this.weightOfContener = weightOfContener;
        this.maxLoadWeight = maxLoadWeight;
        this.serialNumber = $"KON-{typeOfCointaner}-{id++}";
    }

    public virtual void emptyContener()
    {
        weightOfLoad = 0;
    }

    public virtual void LoadContener(int weight)
    {
        if (weight + weightOfLoad> maxLoadWeight)
            throw new OverfillException("too much weight");
        weightOfLoad += weight;
    }

    public override string ToString()
    {
        return $"Container: {serialNumber} + current height: {height} weight of load: {weightOfLoad} max load weight: {maxLoadWeight} weight of container {weightOfContener}";
    }
}
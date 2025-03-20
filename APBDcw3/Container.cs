namespace APBDcw3;

public abstract class Container
{
    protected double weightOfLoad { get; set; }

    protected double height { get; set; }

    protected double weightOfContener { get; set; }

    protected String serialNumber { get; set; }

    protected double maxLoadWeight { get; set; }

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
}
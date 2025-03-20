namespace APBDcw3;

public abstract class Container
{
    private int weightOfLoad { get; set; }

    private int height { get; set; }

    private int weightOfContener { get; set; }

    private String serialNumber { get; set; }
    
    private int maxLoadWeight { get; set; }

    public void emptyContener()
    {
        weightOfLoad = 0;
    }

    public void LoadContener(int weight)
    {
        if (weight + weightOfLoad> maxLoadWeight)
            throw new OverfillException("too much weight");
        weightOfLoad += weight;
    }
}
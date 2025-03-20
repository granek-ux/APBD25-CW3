namespace APBDcw3;

public class ContainerShip
{
    private List<Container> containers { get; set; }
    private double maxSpeed { get; set; }
    private int maxCointaners { get; set; }
    private double maxWeightOfContainers { get; set; }
    
    private double currentWeightOfContainer { get; set; }


    public ContainerShip(double maxSpeed, int maxCointaners, double maxWeightOfContainer)
    {
        this.maxSpeed = maxSpeed;
        this.maxCointaners = maxCointaners;
        this.maxWeightOfContainers = maxWeightOfContainer;
        currentWeightOfContainer = 0;
        this.containers = new List<Container>();
    }

    public void addContainer(Container container)
    {
        if (container.weightOfLoad +currentWeightOfContainer < maxWeightOfContainers)
            this.containers.Add(container);
        else
        {
            throw new OverfillException("Container is overlapping.");
        }
    }

    public void replaceContainer(String oldSerialNumber, Container container)
    {
        // this.containers.Find()
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
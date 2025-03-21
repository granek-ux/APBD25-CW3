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
        this.containers = [];
    }

    public void addContainer(Container container)
    {
        if (container.weightOfLoad + currentWeightOfContainer < maxWeightOfContainers * 1000)
            this.containers.Add(container);
        else
        {
            throw new OverfillException("Container is overlapping.");
        }
    }

    public void addListOfContainers(List<Container> listOfContainers)
    {
        foreach (Container con in listOfContainers)
        {
            addContainer(con);
        }
    }

    public void replaceContainer(String oldSerialNumber, Container container)
    {
        Container? find = containers.Find( c => c.serialNumber.Equals(oldSerialNumber));
        if (find != null)
        {
            if (currentWeightOfContainer + container.weightOfLoad - find.weightOfLoad < maxWeightOfContainers * 1000)
            {
                container.weightOfLoad += container.weightOfLoad - find.weightOfLoad;
                containers.Remove(find);
                containers.Add(container);
            }
            else
            {
                throw new OverfillException("Container is overlapping.");
            }
        }
    }

    public void removeContainer(String serialNumber)
    {
        Container? find = containers.Find( c => c.serialNumber.Equals(serialNumber));
        if (find != null)
        {
            containers.Remove(find);
            currentWeightOfContainer -= find.weightOfLoad;
        }
        
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
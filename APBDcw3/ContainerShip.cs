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
        {
            this.containers.Add(container);
            currentWeightOfContainer += container.weightOfLoad;
        }
        else
        {
            throw new OverfillException("ContainerShip is overlapping.");
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
                throw new OverfillException("Ship is overlapping.");
            }
        }
    }

    private void calculateLoadWeight()
    {
        currentWeightOfContainer = 0;
        foreach (Container c in containers)
        {
            currentWeightOfContainer += c.weightOfLoad;
        }
    }

    public void unloadContainer(String serialNumber)
    {
        containers.Find( c => c.serialNumber.Equals(serialNumber))?.emptyContener();
        calculateLoadWeight();
        
        Console.WriteLine($"Contoner {serialNumber} unloaded.");
    }

    private Container? takeOutContainer(string serialNumber)
    {
        Container? find = containers.Find( c => c.serialNumber.Equals(serialNumber));
        removeContainer(serialNumber);
        return find;
    }

    public static void moveContainer(String serialNumber, ContainerShip oldContainerShip,
        ContainerShip newContainerShip)
    {
        Container? container = oldContainerShip.takeOutContainer(serialNumber);

        if (container != null) newContainerShip.addContainer(container);
        else Console.WriteLine("No such container");
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

    public string getInfoShpi()
    {
        String info = $"ship: max speed {maxSpeed}kn, max number of containers {maxCointaners}, number of containers {containers.Count},max weight {maxWeightOfContainers}, current weight {currentWeightOfContainer} \n";
        info += "Info about containers: \n";
        foreach (Container c in containers)
            info += c.ToString() + " \n";
        
        return info;
    }
    
    public string getInfoContainer(String serialNumber)
    {
        Container? find = containers.Find( c => c.serialNumber.Equals(serialNumber));
        if (find != null)
            return find.ToString();
        
        return "No such container on ship";
    }

}
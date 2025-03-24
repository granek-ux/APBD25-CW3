namespace APBDcw3;

public class ColdCointaner : Container, IHazardNotifer
{
    public Products typeOfProduct { get; set; }
    public double temperature { get; set; }
    private Dictionary<Products, double> productDictionary;

    public ColdCointaner(double weightOfLoad, double height, double weightOfContener, double maxLoadWeight,
        Products typeOfProduct, double temperature) : base("C", weightOfLoad, height, weightOfContener, maxLoadWeight)
    {
        this.typeOfProduct = typeOfProduct;
        this.temperature = temperature;

        this.productDictionary = new Dictionary<Products, double>
        {
            { Products.Banana, 13.3 },
            { Products.Chocolate, 18 },
            { Products.Fish, 2 },
            { Products.Meat, -15 },
            { Products.Ice_Cream, -18 },
            { Products.Frozen_Pizza, -30 },
            { Products.Cheese, 7.2 },
            { Products.Sausage, 5 },
            { Products.Butter, 20.5 },
            { Products.Eggs, 19 }
        };
        
        if(productDictionary[typeOfProduct] < temperature)
            throw new LowTemperatureException("Low temperature");
    }


    public void NotifyHazard()
    {
        Console.WriteLine("Alert of dangerous action in ColdContainer: " + serialNumber);
    }
    
    public void LoadContener(double weight, Products product)
    {
        if (!product.Equals(this.typeOfProduct))
        {
            Console.WriteLine($"Wrong product type it shoudl be {product}");
            return;
        }
        if(weight  + weightOfLoad > this.maxLoadWeight)
            throw new OverfillException("Overfill");
        
        this.weightOfLoad += weight;
    }

    public override string ToString()
    {
        return base.ToString() + $" product {typeOfProduct} temperature {temperature}";
    }
}
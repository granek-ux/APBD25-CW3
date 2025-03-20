namespace APBDcw3;

public interface IHazardNotifer
{
    public void sentMessage(string contenerName)
    {
        Console.WriteLine("Dangerous situation in the container: " + contenerName);
    }
}
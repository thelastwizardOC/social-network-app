namespace DesignPattern.Singleton;

public class Sun
{
    private static Sun _instance = null;
    private Sun(){}

    public static Sun GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Sun();
        }
        return _instance;
    }

    public void EmitLight()
    {
        Random random = new Random();
        
        Console.WriteLine("The Sun emits light, UV Index = {0}", random.Next(1, 30));
    }
}
using System;

#region FactoryImplementation
public interface ICar {
    void Operate();
}

class Mercedes : ICar
{
    public void Operate()
    {
        Console.WriteLine("Mercedes mrun");
    }
}

class BMW : ICar
{
    public void Operate()
    {
        Console.WriteLine("BMW brun");
    }
}

class Toyota : ICar
{
    public void Operate()
    {
        Console.WriteLine("Toyota trun");
    }
}

public class CarFactory
{
    public ICar CreateCar(string name)
    {
        switch (name)
        {
            case "Mercedes":
                return new Mercedes();
            case "BMW":
                return new BMW();
            case "Toyota":
                return new Toyota();
            default:
                return null;    
        }
    }
}
#endregion

#region Program
public class Program
{
    public static void Main(string[] args)
    { 
        CarFactory factory = new CarFactory();
        ICar merCar = factory.CreateCar("Mercedes");
        ICar bmwCar = factory.CreateCar("BMW");
        ICar toyota = factory.CreateCar("Toyota");

        merCar.Operate();
        bmwCar.Operate();
        toyota.Operate();   
    }
}
#endregion
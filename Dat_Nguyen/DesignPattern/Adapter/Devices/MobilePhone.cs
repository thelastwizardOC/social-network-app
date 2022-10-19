namespace DesignPattern.Adapter.Devices;

public class MobilePhone
{
    public string _type { get; set; }

    public MobilePhone(string type)
    {
        _type = type;
    }

    public void Call(int number)
    {
        Console.WriteLine("{0} is making a call to {1}",_type, number);
    }
}
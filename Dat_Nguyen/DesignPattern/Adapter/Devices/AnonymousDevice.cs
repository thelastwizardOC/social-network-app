namespace DesignPattern.Adapter.Devices;

public class AnonymousDevice
{
    public string DeviceName { get; set; }
    public int NumberPhone { get; set; }

    public AnonymousDevice(string name, int numberPhone)
    {
        DeviceName = name;
        NumberPhone = numberPhone;
    }
}
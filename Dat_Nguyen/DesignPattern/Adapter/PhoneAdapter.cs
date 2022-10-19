using DesignPattern.Adapter.Devices;
using DesignPattern.Adapter.Interfaces;

namespace DesignPattern.Adapter;

public class PhoneAdapter:IDevice
{
    public MobilePhone mobilePhone { get; } = new MobilePhone("Iphone 14 Pro");
    public int phone { get; }

    public PhoneAdapter(AnonymousDevice device)
    {
        phone = device.NumberPhone;
    }
    public void MakeACall()
    {
        Console.WriteLine("Dialing ...");
        mobilePhone.Call(phone);
    }
    
}
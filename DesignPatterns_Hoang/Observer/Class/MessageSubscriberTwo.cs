namespace Observer.Class;

public class MessageSubscriberTwo:IObserver
{
    public void update(String message)
    {
        Console.WriteLine("MessageSubscriberTwo :: " + message);
    }
}
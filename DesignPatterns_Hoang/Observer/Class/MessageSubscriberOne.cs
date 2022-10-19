namespace Observer.Class;

public class MessageSubscriberOne:IObserver
{
    public void update(String message)
    {
        Console.WriteLine("MessageSubscriberOne :: " + message);
    }
}
namespace Observer.Class;

public class MessagePublisher
{
    private List<IObserver> observers = new List<IObserver>();

    public void attach(IObserver o)
    {
        observers.Add(o);
    }

    public void detach(IObserver o)
    {
        observers.Remove(o);
    }

    public void notifyUpdate(String message)
    {
        observers.ForEach(o=>o.update(message));
    }
}
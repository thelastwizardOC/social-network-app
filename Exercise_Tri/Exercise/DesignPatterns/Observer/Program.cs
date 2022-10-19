using System.Collections;

#region Store
public class Store
{
    private readonly NotificationService _notificationService;

    public Store()
    {
        _notificationService = new NotificationService();
    }

    public NotificationService GetNotifcationService()
    {
        return _notificationService;
    }

    public void NewProduct()
    {
        _notificationService.Notify();
    }
}
#endregion

#region NotificationService
public class NotificationService
{
    private List<EmailMsgListener> _customers;
    
    public NotificationService()
    {
        _customers = new List<EmailMsgListener>();
    }

    public void Subscribe(EmailMsgListener listener)
    {
        _customers.Add(listener);
    }

    public void Unsubscribe(EmailMsgListener listener)
    {
        _customers.Remove(listener);
    }

    public void Notify()
    {
        foreach (var customer in _customers)
        {
            customer.Update();
        }
    }
}
#endregion

#region EmailMsgListener
public class EmailMsgListener
{
    private string _email;
    
    public EmailMsgListener(string email)
    {
        this._email = email;
    }

    public void Update()
    {
        Console.WriteLine("Send email to " + _email);
    }
}
#endregion

#region Program
public class Program
{
    public static void Main(string[] args)
    {
        Store store = new Store();

        EmailMsgListener triListener = new EmailMsgListener("tri@gmail.com");
        EmailMsgListener datListener = new EmailMsgListener("dat@gmail.com");
        EmailMsgListener hoangListener = new EmailMsgListener("hoang@gmail.com");
        
        store.GetNotifcationService().Subscribe(triListener);
        store.GetNotifcationService().Subscribe(datListener);
        store.GetNotifcationService().Subscribe(hoangListener);
        store.NewProduct();
        
        store.GetNotifcationService().Unsubscribe(hoangListener);
        store.NewProduct();
    }
}
#endregion
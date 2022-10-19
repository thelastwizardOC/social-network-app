// a class has only one instance and provide a global point of access to it.
using System;

#region SingletonClass
public class Singleton 
{
    private static volatile Singleton _instance;
    /* static prop for static method 
     * volatile kw hanldes reference a partially constructed object (not finished) --> crash
     * problem ...
     */
    // private static Singleton _instance = new Singleton(); => created even when not used
    
    private Singleton () 
    {  
    }

    public static Singleton GetInstance() {
        if (_instance != null) { // threads not necessarily obtain lock
            lock (typeof(Singleton)) { // thread wait (threads access code at the same time)
                if (_instance == null) // guarantee the same instance is returned
                {
                    _instance = new Singleton();
                }
            }
        }
        return _instance;
    }
}
#endregion

#region Program
public class Program
{
    public static void Main(string[] args)
    {
        Singleton objectA = Singleton.GetInstance();
        Singleton objectB = Singleton.GetInstance();

        Console.WriteLine(objectA == objectB);
    }
}
#endregion
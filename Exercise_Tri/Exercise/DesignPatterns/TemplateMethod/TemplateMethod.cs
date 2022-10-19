using System;

#region TemplateMethodImplementation
public abstract class BaseGameLoader 
{
    public void Load()
    {
        LoadLocalFile();
        CreateObject();
        DownloadAdditionalSource();
        CleanTempFile();
        LoadPlayerProfile();
    }

    protected abstract void LoadLocalFile();
    protected abstract void CreateObject();
    protected abstract void DownloadAdditionalSource();
    protected abstract void LoadPlayerProfile();

    protected void CleanTempFile() {
        Console.WriteLine("Cleaning temporary files ...");
    }
}

public class DuelLinksLoader : BaseGameLoader
{
    protected override void LoadLocalFile()
    {
        Console.WriteLine("Loading Duel Links local files ...");
    }

    protected override void CreateObject()
    {
        Console.WriteLine("Creating Duel Links objects ...");
    }

    protected override void DownloadAdditionalSource()
    {
        Console.WriteLine("Downloading Duel Links additional images ...");
    }

    protected override void LoadPlayerProfile()
    {
        Console.WriteLine("Loading Duel Links player profile ...");
    }
}

public class MasterDuelLoader : BaseGameLoader
{
    protected override void LoadLocalFile()
    {
        Console.WriteLine("Loading Master Duel local files ...");
    }

    protected override void CreateObject()
    {
        Console.WriteLine("Creating Master Duel objects ...");
    }

    protected override void DownloadAdditionalSource()
    {
        Console.WriteLine("Downloading Master Duel additional images ...");
    }

    protected override void LoadPlayerProfile()
    {
        Console.WriteLine("Loading Master Duel player profile ...");
    }
}
#endregion

#region Program
public class Program
{
    public static void Main(string[] args)
    { 
        BaseGameLoader masterDuelloader = new MasterDuelLoader();
        masterDuelloader.Load();
        Console.WriteLine("------------------------------");
        BaseGameLoader duelLinksloader = new DuelLinksLoader();
        duelLinksloader.Load();
    }
}
#endregion
// See https://aka.ms/new-console-template for more information
public class AsyncProgram
{
    public static void Main(string[] args)
    {
        Console.WriteLine(AsyncProgramming());
        Console.WriteLine(GetUrlContentLengthAsync());  
    }
    
    private static async Task<string> AsyncProgramming()
    {
        var httpClient = new HttpClient();

        Task<HttpResponseMessage> getRandomUser = httpClient.GetAsync("https://random-data-api.com/api/users/random_user");
        DoIndependentWork();

        HttpResponseMessage res = await getRandomUser;
        string resBody = await res.Content.ReadAsStringAsync();
        Console.WriteLine("This is response: ", resBody);
        return resBody;
    }

    public static async Task<int> GetUrlContentLengthAsync()
    {
        var client = new HttpClient();

        Task<string> getStringTask =
            client.GetStringAsync("https://docs.microsoft.com/dotnet");

        DoIndependentWork();

        string contents = await getStringTask;

        return contents.Length;
    }

    static void DoIndependentWork()
    {
        Console.WriteLine("Working...");
    }
}

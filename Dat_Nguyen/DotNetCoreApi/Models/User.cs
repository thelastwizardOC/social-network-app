namespace DotNetCoreApi.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Job { get; set; }
    public bool IsMale { get; set; }

    public User(int id, string name, string job, bool isMale)
    {
        Id = id;
        Name = name;
        Job = job;
        IsMale = isMale;
    }
}
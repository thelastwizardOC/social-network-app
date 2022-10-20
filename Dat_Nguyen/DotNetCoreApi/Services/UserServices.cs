using DotNetCoreApi.Models;

namespace DotNetCoreApi.Services;

public class UserServices
{
    private readonly List<User> _users = new ()
    {
        new User(0, "John","Developer",true),
        new User(1,"Jack","Tester", true)
    };

    public List<User> GetAllUsers() => _users;

    public User? GetTargetUser(int id) => _users.FirstOrDefault(user => user.Id == id);

    public List<User> AddNewUser(User newUser)
    {
        User user = new User(_users.Count,newUser.Name, newUser.Job, newUser.IsMale);
        _users.Add(user);
        return _users;
    }

    public User? UpdateUserInfo(int id, User updatedUser)
    {
        var user = GetTargetUser(id);
        if (user is null)
        {
            return null;
        }

        _users[user.Id] = updatedUser;
        return updatedUser;
    }

    public List<User>? DeleteUser(int id)
    {
        var index = _users.FindIndex(user => user.Id == id);
        if (index == -1)
        {
            return null;
        }

        _users.RemoveAt(id);
        return _users;
    }
}
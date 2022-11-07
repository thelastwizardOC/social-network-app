using System.ComponentModel.DataAnnotations;

namespace SocialWebApp.Models;

public class UserFriends
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    
    
    public int SourceUserId { get; set; }
    public User SourceUser { get; set; }

    public int FriendId { get; set; }
    public User Friend { get; set; }

}
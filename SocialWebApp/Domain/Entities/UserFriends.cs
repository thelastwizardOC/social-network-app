using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class UserFriends
{
<<<<<<< HEAD
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public bool IsDeleted { get; set; }


  public int SourceUserId { get; set; }
  public User SourceUser { get; set; }

  public int FriendId { get; set; }
  public User Friend { get; set; }
=======
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    
    
    public int SourceUserId { get; set; }
    public User SourceUser { get; set; }

    public int FriendId { get; set; }
    public User Friend { get; set; }
>>>>>>> 9388498 (fix: remove unnecessary validation login form + config returned access token with user id + fix nav bar)

}
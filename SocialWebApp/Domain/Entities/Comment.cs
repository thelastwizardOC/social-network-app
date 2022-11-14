<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> 9388498 (fix: remove unnecessary validation login form + config returned access token with user id + fix nav bar)

namespace Domain.Entities;

public class Comment
{
  public int Id { get; set; }
  public string Content { get; set; }
  public string Photo { get; set; }
  public DateTime CreatedAt { get; set; }

  public User User { get; set; }
  public int UserId { get; set; }

  public Post Post { get; set; }
  public int PostId { get; set; }

}
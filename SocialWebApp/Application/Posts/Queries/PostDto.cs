using Domain.Entities;

namespace Application.Posts.Queries;

public class PostDto
{
  public int Id { get; set; }
  public string Status { get; set; }
  public string Photo { get; set; }
  public int NumberOfLikes { get; set; }
  public int NumberOfComments { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public List<Comment>? Comments { get; set; }
  public int UserId { get; set; }
  public User User { get; set; }
  public List<PostLike>? PostLikes { get; set; }
}
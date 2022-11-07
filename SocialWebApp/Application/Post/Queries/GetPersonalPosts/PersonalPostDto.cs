using SocialWebApp.Models;

namespace Application.Post.Queries.GetPersonalPosts;

public class PersonalPostDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
    public string Photo { get; set; }
    public int NumberOfLikes { get; set; }
    public int NumberOfComments { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    
    public List<Comment>?  Comments { get; set; }

    public int UserId { get; set; }
    public SocialWebApp.Models.User User { get; set; }
}
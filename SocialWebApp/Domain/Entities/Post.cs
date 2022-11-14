namespace Domain.Entities;

public class Post
{
    public int Id { get; set; }
    public string Status { get; set; }
    public string Photo { get; set; }
    public int NumberOfLikes { get; set; }
    public int NumberOfComments { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    
    public List<Comment>?  Comments { get; set; }

    public User User { get; set; }


}
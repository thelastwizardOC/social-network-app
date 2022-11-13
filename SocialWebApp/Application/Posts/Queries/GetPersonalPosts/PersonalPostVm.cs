namespace Application.Posts.Queries.GetPersonalPosts;

public class PersonalPostVm
{

    public List<PersonalPostDto> Items { get; set; }
    public int TotalCount { get; set; }
    public bool HasNextPage { get; set; }
    
}
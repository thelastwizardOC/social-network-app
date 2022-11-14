namespace Application.Posts.Queries.GetNewsfeedPosts;

public class NewsfeedPostVm
{
    public List<NewsfeedPostDto> Items { get; set; }
    public int TotalCount { get; set; }
    public bool HasNextPage { get; set; }
}
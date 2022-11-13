using Application.Posts.Queries.GetPersonalPosts;
using Microsoft.AspNetCore.Mvc;
namespace WebUI.Controllers;


public class PostController:ApiControllerBase 
{
    [HttpGet("{userId}")]
    public async Task<ActionResult<PersonalPostVm>> GetUserPosts(int userId, int offset=0, int limit=100 )
    {
        if (userId == null) return NotFound();
        return await Mediator.Send(new GetPersonalPostsQuery()
        {
            UserId = userId,
            Offset = offset,
            Limit =limit
        });
    }
}
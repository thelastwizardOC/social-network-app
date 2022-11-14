using Application.Posts.Queries.GetPersonalPosts;
using Application.Posts.Queries.GetNewsfeedPosts;
using Microsoft.AspNetCore.Mvc;
namespace WebUI.Controllers;


public class PostController:ApiControllerBase 
{
    [HttpGet("{userId}")]
    public async Task<ActionResult<PersonalPostVm>> GetUserPosts(int userId, int offset=0, int limit=100 )
    {
        if (userId == null) return BadRequest();
        return await Mediator.Send(new GetPersonalPostsQuery()
        {
            UserId = userId,
            Offset = offset,
            Limit =limit
        });
    }
    
        
    [HttpGet("newsfeed/{userId}")]
    public async Task<ActionResult<NewsfeedPostVm>> GetNewsfeedPosts(int userId,int offset=0, int limit=100)
    {
        if (userId == null) return BadRequest();
        return await  Mediator.Send(new GetPostsQuery()
        {
            UserId = userId,
            Offset = offset,
            Limit = limit
        });
        

    }

}
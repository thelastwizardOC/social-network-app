using Application.Common.Exceptions;
using Application.Posts.Commands.LikePost;
using Application.Posts.Queries;
using Application.Posts.Queries.GetPersonalPosts;
using Application.Posts.Queries.GetNewsfeedPosts;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;


namespace WebUI.Controllers;

public class PostController : ApiControllerBase
{
    [HttpGet("{userId}")]
    public async Task<ActionResult<PaginatedPostDto>> GetUserPosts(int userId, int offset = 0, int limit = 100)
    {
        try
        {
            if (userId == null) return BadRequest();
            return await Mediator.Send(new GetPersonalPostsQuery() { UserId = userId, Offset = offset, Limit = limit });
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
   
    }

    [HttpPost("like")]
    public async Task<ActionResult<PostDto>> LikePost(int postId, int userId)
    {
        try
        {
            Console.WriteLine(postId);
            if (postId == null) return BadRequest();
            return await Mediator.Send(new LikePostCommand() { PostId = postId, UserId = userId });
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }


    [HttpGet("newsfeed/{userId}")]
    public async Task<ActionResult<PaginatedPostDto>> GetNewsfeedPosts(int userId, int offset = 0, int limit = 100)
    {
        try
        {
            if (userId == null) return BadRequest();
            return await Mediator.Send(new GetPostsQuery() { UserId = userId, Offset = offset, Limit = limit });
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
}
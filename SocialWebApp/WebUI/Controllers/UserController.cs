using Application.Common.Exceptions;
using Application.Common.Models;
using Application.Users.Commands.UploadAvatar;
using Application.Users.Commands.UploadCover;
using Application.Users.Queries.GetUserInfo;
using Application.Users.Queries.SearchFriends;
using Application.Users.Queries.SearchUsers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class UserController : ApiControllerBase
{
    [HttpGet("{userId}")]
    public async Task<ActionResult<UserDto>> GetUserInfo(int userId)
    {
        try
        {
            var foundUser = await Mediator.Send(new GetUserInfoQuery() { UserId = userId });
            return Ok(foundUser);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
        catch (ValidationException e)
        {
            return BadRequest();

        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
     
    }
    [HttpGet("friend")]
    public async Task<ActionResult<List<UserFriendDto>>> GetUserFriends([FromQuery]SearchFriendsQuery query)
    {
        try
        {
            var foundUser = await Mediator.Send(query);
            return Ok(foundUser);
        }
        catch (ValidationException e)
        {
            return BadRequest();

        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpPost("upload-avatar")]
    public async Task<ActionResult<string>> UploadAvatar(int userId, IFormFile formFile)
    {
        try
        {
            var file = new FileDto
            {
                Content = formFile.OpenReadStream(),
                Name = formFile.FileName,
                ContentType = formFile.ContentType,
            };

            var url = await Mediator.Send(new UploadAvatarCommand(userId, file));
            return Ok(url);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ValidationException e)
        { 
            return BadRequest(e.Errors);
        }
    }

    [HttpPost("upload-cover")]
    public async Task<ActionResult<string>> UploadCover(int userId, IFormFile formFile)
    {
        try
        {
            var file = new FileDto
            {
                Content = formFile.OpenReadStream(),
                Name = formFile.FileName,
                ContentType = formFile.ContentType,
            };
            var url = await Mediator.Send(new UploadCoverCommand(userId, file));

            return Ok(url);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    [HttpGet("search")]
    public async Task<ActionResult<SearchUsersListDto>> SearchUser([FromQuery] SearchUsersQuery query)
    
    {
        try
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
}
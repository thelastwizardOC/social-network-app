using Application.Common.Exceptions;
using Application.User.Commands.UploadAvatar;
using Application.User.Queries.GetUserInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class UserController : ApiControllerBase
{
    [HttpGet("{userId}")]
    public async Task<ActionResult<UserDto>> GetUserInfo(int userId)
    {
        if (userId == null) return NotFound();
        
        var foundUser= await Mediator.Send(new GetUserInfoQuery()
        {
            UserId = userId
        });
        if (foundUser == null) return NotFound();
        return Ok(foundUser);
    }
    
    [HttpPost("upload-avatar")]
    public async Task<ActionResult<string>> UploadAvatar(UploadAvatarCommand command)
    {
        try
        {
            var base64 = await Mediator.Send(command);
            return Ok(base64);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ValidationException e)
        { 
            return BadRequest(e.Message);
        }
    }

    [HttpPost("upload-cover")]
    public async Task<ActionResult<string>> UploadCover(UploadCoverCommand command)
    {
        try
        {
            var base64 = await Mediator.Send(command);
            return Ok(base64);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }
}
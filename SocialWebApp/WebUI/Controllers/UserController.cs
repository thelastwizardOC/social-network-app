using Application.Common.Exceptions;
using Application.Common.Models;
using Application.Users.Commands.UploadAvatar;
using Application.Users.Commands.UploadCover;
using Application.Users.Queries.GetUserInfo;
using Domain.Entities;
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
            return BadRequest(e.Message);
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
            return BadRequest(e.Message);
        }
    }
}
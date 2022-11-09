using Application.User.Queries.GetUserInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialWebApp.Models;

namespace WebUI.Controllers;

public class UserController :ApiControllerBase 
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
    
}
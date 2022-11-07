using Application.User.Queries.GetUserInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialWebApp.Models;

namespace WebUI.Controllers;

public class UserController :ApiControllerBase 
{
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetUserInfo()
    {
        return await Mediator.Send(new GetUserInfoQuery());

    }
    
}
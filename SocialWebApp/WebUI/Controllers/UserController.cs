using Application.User.Queries.GetUserInfo;
using Microsoft.AspNetCore.Mvc;
using SocialWebApp.Models;

namespace WebUI.Controllers;

public class UserController :ApiControllerBase 
{
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetUserInfo()
    {
        return await Mediator.Send(new GetUserInfoQuery());

    }
    
}
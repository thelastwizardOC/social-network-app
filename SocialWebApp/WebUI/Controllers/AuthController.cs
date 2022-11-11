using Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class AuthController : ApiControllerBase
{
    private readonly ISender _mediator;

    public AuthController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    // POST
    [HttpPost("register")]
    public async Task<ActionResult<NewUserVm>> Register(NewUserDto newUserDto)
    {
        var newUser = await _mediator.Send(new RegisterCommand(){NewUserDto = newUserDto});
        if (newUser == null)
        {
            return BadRequest("User is existed");
        }

        return Ok(newUser);
    }
}
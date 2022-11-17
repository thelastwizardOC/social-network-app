using Application.Common.Exceptions;
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
        try
        {
            var newUser = await _mediator.Send(new RegisterCommand() { NewUserDto = newUserDto });
            if (newUser == null)
            {
                return BadRequest("User has been existed");
            }

            return Ok(newUser);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }
}
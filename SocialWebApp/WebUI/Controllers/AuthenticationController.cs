using Application.Common.Models;
using Application.Users.Commands.RefreshToken;
using Application.Users.Queries.Login;
using Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResult>> Login(LoginQuery request)
        {
            var authenticationResult = await _mediator.Send(request);

            if (authenticationResult.IsError && authenticationResult.FirstError == AuthenticationError.InvalidCredentials)
            {
                return Unauthorized();
            }
            return Ok(authenticationResult.Value);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<AuthenticationResult>> Refresh(RefreshTokenCommand command)
        {
            if (command is null)
                return BadRequest("Invalid client request");

            var refreshTokenResult = await _mediator.Send(command);
            if (refreshTokenResult.IsError && refreshTokenResult.FirstError == AuthenticationError.InvalidCredentials)
            {
                return Unauthorized();
            }

            return Ok(refreshTokenResult.Value);
        }
    }
}

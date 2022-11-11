using Application.Users.Queries.GetUserInfo;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class UserController : ApiControllerBase
{

  [HttpGet("{userId}")]
  public async Task<ActionResult<UserDto>> GetUserInfo(int userId)
  {
    try
    {
      if (userId == null) return BadRequest();
      var foundUser = await Mediator.Send(new GetUserInfoQuery()
      {
        UserId = userId
      });
      if (foundUser == null) return NotFound();
      return Ok(foundUser);
    }
    catch (Exception e)
    {
      return StatusCode(500);
    }


  }

}
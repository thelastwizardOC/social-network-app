using DotNetCoreApi.Models;
using DotNetCoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private UserServices _userServices = new ();
    
    [HttpGet(Name = "GetAllUsers")]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        return Ok(_userServices.GetAllUsers());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var result = _userServices.GetTargetUser(id);
        if (result is null)
        {
            return BadRequest("Id is not found!");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<User>>> AddNewUser(User user)
    {
        var result = _userServices.AddNewUser(user);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest("Wrong Id");
        }
        
        var result = _userServices.UpdateUserInfo(id, user);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var result = _userServices.DeleteUser(id);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
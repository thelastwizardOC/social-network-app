using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApi.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
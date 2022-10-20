using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApi.Controllers;

public class ZooController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
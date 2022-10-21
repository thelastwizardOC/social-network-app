using EFCore.Data;
using EFCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassController : Controller
{
    private static DataContext context;
    private ClassServices _classServices = new(context);

    public ClassController(DataContext ctx)
    {
        context = ctx;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<object>>> GetAll()
    {
        return Ok( _classServices.GetAllInfo());
    }
}
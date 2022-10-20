using DotNetCoreApi.Interfaces;
using DotNetCoreApi.Models;
using DotNetCoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ZooController : ControllerBase
{
   private readonly ZooServices _zooServices = new ();

   [HttpGet("GetAnimals")]
   public List<Animal> GetAllAnimals()
   {
      return _zooServices.GetAll().ToList();
   }

   [HttpGet("GetMammals")]
   public List<Animal> GetMammals() => _zooServices.GetMammals().ToList();
   
   [HttpGet("GetBirds")]
   public List<Animal> GetBirds() => _zooServices.GetBirds().ToList();
}
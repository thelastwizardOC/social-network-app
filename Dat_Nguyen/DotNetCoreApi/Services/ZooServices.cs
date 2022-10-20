using DotNetCoreApi.Interfaces;
using DotNetCoreApi.Models;

namespace DotNetCoreApi.Services;

public class ZooServices
{
    private List<Animal> _animals { get; }

    public ZooServices()
    {
        _animals = new List<Animal>()
        {
            new Mammal("0", "By body"),
            new Mammal("1", "By 2 Legs"),
            new Bird("2", "By Wings")
        };
    }

    public IEnumerable<Animal> GetAll()
    {
        _animals[0].SetMoving("By 4 Legs");
        return _animals;
    }

    public IEnumerable<Animal> GetMammals() =>
         _animals.Where(a => a is Mammal);
       
    
    public IEnumerable<Animal> GetBirds() => 
        _animals.Where(a => a is Bird);
    
}
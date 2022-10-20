using System.Runtime.CompilerServices;
using DotNetCoreApi.Interfaces;

namespace DotNetCoreApi.Models;

public abstract class Animal
{
    public string IdCode { get; set; }
    public string MovingMethod { get; set; }

    protected Animal(string idCode, string movingMethod)
    {
        IdCode = idCode;
        MovingMethod = movingMethod;
    }

    public void SetMoving(string moving)
    {
        MovingMethod = moving;
    }
}

public class Mammal: Animal, IAnimalFunction
{
    public Mammal(string idCode, string movingMethod) : base(idCode, movingMethod)
    {
    }

    public string GetIdCode() => IdCode;

    public new void SetMoving(string moving) => base.SetMoving(moving);
}
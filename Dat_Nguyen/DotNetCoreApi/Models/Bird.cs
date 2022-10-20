using DotNetCoreApi.Interfaces;

namespace DotNetCoreApi.Models;

public class Bird : Animal, IAnimalFunction
{
    public Bird(string idCode, string movingMethod) : base(idCode, movingMethod)
    {}
    public string GetIdCode() => IdCode;

    public void SetMoving(string moving)
    {
        MovingMethod = moving;
    }
}
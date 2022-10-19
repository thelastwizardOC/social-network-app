using DesignPattern.FactoryMethod.Interfaces;

namespace DesignPattern.FactoryMethod.Shapes;

public class Rectangle:IShape
{
    public string GetShape()
    {
        return "Regtangle";
    }
}
using DesignPattern.FactoryMethod.Interfaces;

namespace DesignPattern.FactoryMethod.Shapes;

public class Circle:IShape
{
    public string GetShape()
    {
        return "Circle";
    }
}
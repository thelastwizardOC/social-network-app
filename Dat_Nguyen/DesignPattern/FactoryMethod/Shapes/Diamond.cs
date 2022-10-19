using DesignPattern.FactoryMethod.Interfaces;

namespace DesignPattern.FactoryMethod.Shapes;

public class Diamond:IShape
{
    public string GetShape()
    {
        return "Diamond";
    }
}
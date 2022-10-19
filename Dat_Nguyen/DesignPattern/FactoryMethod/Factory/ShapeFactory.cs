using DesignPattern.FactoryMethod.Interfaces;
using DesignPattern.FactoryMethod.Shapes;

namespace DesignPattern.FactoryMethod.Factory;

public class ShapeFactory:IShapeFactory
{
    public IShape CreateShape()
    {
        Random random = new Random();
        int index = random.Next(0, 3);
        return index == 0 ? new Circle() : index == 1 ? new Diamond() : new Rectangle();
    }
}
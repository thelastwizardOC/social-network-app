namespace Abstract;

public class ShapeFactory : AbstractFactory
{
    public override IShape getShape(ShapeType shapeType)
    {
        if(shapeType == ShapeType.Rectangle){
            return new Rectangle();         
        }else if(shapeType == ShapeType.Square){
            return new Square();
        }	 
        return null;
    }
}
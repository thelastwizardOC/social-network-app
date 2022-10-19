namespace Abstract;

public class RoundedShapeFactory : AbstractFactory
{
    public override IShape getShape(ShapeType shapeType)
    {
        if(shapeType == ShapeType.Rectangle){
            return new RoundedRectangle();         
        }else if(shapeType == ShapeType.Square){
            return new RoundedSquare();
        }	 
        return null;
    }
}
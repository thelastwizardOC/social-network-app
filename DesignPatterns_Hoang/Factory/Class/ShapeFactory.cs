namespace Factory.Class;

public class ShapeFactory {
	
    public Shape createShape(ShapeType shapeType){
        if(shapeType == ShapeType.Circle){
            return new Circle();
         
        } else if(shapeType ==ShapeType.Rectangle){
            return new Rectangle();
         
        } else if(shapeType == ShapeType.Square){
            return new Square();
        }
      
        return null;
    }
}
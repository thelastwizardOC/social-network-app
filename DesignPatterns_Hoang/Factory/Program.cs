using Factory.Class;


ShapeFactory shapeFactory = new ShapeFactory();

Shape shape1 = shapeFactory.createShape(ShapeType.Circle);

shape1.draw();

Shape shape2 = shapeFactory.createShape(ShapeType.Rectangle);

shape2.draw();

Shape shape3 = shapeFactory.createShape(ShapeType.Square);

shape3.draw();
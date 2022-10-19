using Abstract;

AbstractFactory shapeFactory = FactoryProducer.getFactory(false);

IShape shape1 = shapeFactory.getShape(ShapeType.Rectangle);
shape1.draw();

IShape shape2 = shapeFactory.getShape(ShapeType.Square);
shape2.draw();

AbstractFactory shapeFactory1 = FactoryProducer.getFactory(true);

IShape shape3 = shapeFactory1.getShape(ShapeType.Rectangle);
shape3.draw();
IShape shape4 = shapeFactory1.getShape(ShapeType.Square);
shape4.draw();
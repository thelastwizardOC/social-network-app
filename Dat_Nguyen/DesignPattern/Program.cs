using DesignPattern.Adapter;
using DesignPattern.Adapter.Devices;
using DesignPattern.Adapter.Interfaces;
using DesignPattern.FactoryMethod.Factory;
using DesignPattern.FactoryMethod.Interfaces;
using DesignPattern.Prototype;
using DesignPattern.Singleton;

// Singleton
Sun sunSingleton = Sun.GetInstance();
sunSingleton.EmitLight();

Console.ReadLine();

// Factory Method
IShapeFactory shapeFactory;
// Create Factory
shapeFactory = new ShapeFactory();
// Create Shape objects from the Factory
IShape shape = shapeFactory.CreateShape();
Console.WriteLine(shape.GetShape());
Console.WriteLine(shape.GetShape());

Console.ReadLine();

// Adapter
AnonymousDevice tvSamSung = new AnonymousDevice("TV SamSung", 944903221);
IDevice adapter = new PhoneAdapter(tvSamSung);
adapter.MakeACall();

Console.ReadLine();

// Prototype
var garden = new Garden(new Apple("Fuji"), new Banana("Sa pa"));
var fruit1Gen = garden.GrowFruit1().Copy();
var fruit2Gen = garden.GrowFruit2().Copy();
Console.WriteLine(fruit1Gen);
Console.WriteLine(fruit2Gen);

Console.ReadLine();
namespace DesignPattern.Prototype;

public class Apple:Fruit
{
    public string Name { get; }

    public Apple(string name)
    {
        Name = name;
    }
    public override Fruit Copy() => new Apple(Name);

}
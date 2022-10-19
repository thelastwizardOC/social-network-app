namespace DesignPattern.Prototype;

public class Banana:Fruit
{
    public string Name { get; }

    public Banana(string name)
    {
        Name = name;
    }
    public override Fruit Copy() => new Banana(Name);
}
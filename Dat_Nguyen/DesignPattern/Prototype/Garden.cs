namespace DesignPattern.Prototype;

public class Garden
{
    private Fruit _fruit1;
    private Fruit _fruit2;

    public Garden(Fruit fruit1, Fruit fruit2)
    {
        _fruit1 = fruit1;
        _fruit2 = fruit2;
    }

    public Fruit GrowFruit1() => _fruit1.Copy();
    public Fruit GrowFruit2() => _fruit2.Copy();
}
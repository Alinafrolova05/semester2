namespace ControlWork3.Test;

public class Tests
{
    private Vector<int> vector1;
    private Vector<int> vector2;

    [SetUp]
    public void Setup()
    {
        vector1 = new ();
        vector2 = new();
    }

    [Test]
    public void Test()
    {
        vector1.Add(1, 1);
        vector1.Add(2, 1);

        vector2.Add(1, 1);
        vector2.Add(3, 1);

        Vector<int> newVector = new ();
    }
}

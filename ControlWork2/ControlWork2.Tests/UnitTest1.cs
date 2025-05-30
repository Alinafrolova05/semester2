using ControlWork2;

namespace ControlWork2.Tests;

public class Tests
{
    private ControlWork2.List<int> list;

    [SetUp]
    public void Setup()
    {
        list = new ();
    }

    [Test]
    public void Test()
    {
        list.Add (3);
        list.Add (1);
        list.Add (5);
        list.Add (2);
        list.Add (4);

        ListUtils.Sort(list, Comparer<int>.Default);

        for (var i = 1; i <= 5; ++i)
        {
            Assert.That(list.GetValue(i - 1), Is.EqualTo(i));
        }
    }
}

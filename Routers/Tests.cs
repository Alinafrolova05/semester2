using NUnit.Framework;
using Routers;

namespace TestAlgorithm;

public class Test
{
    private string TestFilePath = "";
    ReadFile file;
    AlgoritmPrima algoritm;
    Dictionary<int, Dictionary<int, int>> result;

    [SetUp]
    public void Setup()
    {
        file = new ReadFile(TestFilePath);
        algoritm = new AlgoritmPrima(file);
        result = algoritm.ResultOfAlgoritmPrima();
    }

    [Test]
    public void AddSimpleNumbers()
    {
        File.WriteAllText(TestFilePath, "1: 2 (10), 3 (5)\r\n2: 3 (1)");

        var file = new ReadFile(TestFilePath);
        var algoritm = new AlgoritmPrima(file);
        var result = algoritm.ResultOfAlgoritmPrima();

        Assert.That(result[1][2], Is.EqualTo(10));
        Assert.That(result[1][3], Is.EqualTo(5));
        Assert.That(!result.ContainsKey(2));
    }

    [Test]
    public void TestReadFile()
    {
        File.WriteAllText(TestFilePath, "1: 2 (10), 3 (5)\r\n2 3 (1)");

        var exeption1 = Assert.Throws<ArgumentNullException>(() => new ReadFile(TestFilePath));
        Assert.That(exeption1.Message, Does.Contain(TestFilePath));

        File.WriteAllText(TestFilePath, "1: 2 (10), 3 (5)\r\n2: 3 1)");

        var exeption2 = Assert.Throws<InvalidOperationException>(() => new ReadFile(TestFilePath));
        Assert.That(exeption2.Message, Does.Contain(TestFilePath));

        File.WriteAllText(TestFilePath, "1: 2 (10, 3 (5)\r\n2: 3 (1)");

        var exeption3 = Assert.Throws<InvalidOperationException>(() => new ReadFile(TestFilePath));
        Assert.That(exeption3.Message, Does.Contain(TestFilePath));

        File.WriteAllText(TestFilePath, "1:  (10), 3 (5)\r\n2: 3 (1)");

        var exeption4 = Assert.Throws<InvalidOperationException>(() => new ReadFile(TestFilePath));
        Assert.That(exeption4.Message, Does.Contain(TestFilePath));

        File.WriteAllText(TestFilePath, "1: \r\n2: 3 (1)");

        var exeption5 = Assert.Throws<InvalidOperationException>(() => new ReadFile(TestFilePath));
        Assert.That(exeption5.Message, Does.Contain(TestFilePath));

        File.WriteAllText(TestFilePath, "\r\n2: 3 (1)");

        var exeption6 = Assert.Throws<InvalidOperationException>(() => new ReadFile(TestFilePath));
        Assert.That(exeption6.Message, Does.Contain(TestFilePath));
    }

    [Test]
    public void TestAlgoritmPrima()
    {
        File.WriteAllText(TestFilePath, "1: 2 (10), 3 (1)\r\n2: 3 (5)");
        var file = new ReadFile(TestFilePath);
        var algoritm = new AlgoritmPrima(file);
        var result = algoritm.ResultOfAlgoritmPrima();

        Assert.That(result[1][2], Is.EqualTo(10));
        Assert.That(result[2][3], Is.EqualTo(5));
        Assert.That(!result.ContainsKey(3));

        File.WriteAllText(TestFilePath, "1: 2 (10), 3 (5)\r\n4: 5 (1)");
        file = new ReadFile(TestFilePath);
        algoritm = new AlgoritmPrima(file);
        result = algoritm.ResultOfAlgoritmPrima();

        Assert.That(result[1][2], Is.EqualTo(10));
        Assert.That(result[2][3], Is.EqualTo(5));
        Assert.That(!result.ContainsKey(3));
    }
}

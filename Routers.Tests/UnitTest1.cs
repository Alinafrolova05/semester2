using NUnit.Framework;
using Routers;

namespace TestAlgorithm;

public class Test
{
    private string testFilePath;
    private ReadFile file;
    private Configuration algoritm;
    private Dictionary<int, Dictionary<int, int>> result;

    [SetUp]
    public void Setup()
    {
        this.file = new ReadFile(this.testFilePath);
        this.algoritm = new Configuration(this.file);
        this.result = this.algoritm.ResultConfiguration();
    }

    [Test]
    public void AddSimpleNumbers()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2: 3 (1)");

        var file = new ReadFile(this.testFilePath);
        var algoritm = new Configuration(file);
        var result = algoritm.ResultConfiguration();

        Assert.That(result[1][2], Is.EqualTo(10));
        Assert.That(result[1][3], Is.EqualTo(5));
        Assert.That(!result.ContainsKey(2));
    }

    [Test]
    public void TestReadFile()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2 3 (1)");

        var exeption1 = Assert.Throws<ArgumentNullException>(() => new ReadFile(this.testFilePath));
        Assert.That(exeption1.Message, Does.Contain(this.testFilePath));

        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2: 3 1)");

        var exeption2 = Assert.Throws<InvalidOperationException>(() => new ReadFile(this.testFilePath));
        Assert.That(exeption2.Message, Does.Contain(this.testFilePath));

        File.WriteAllText(this.testFilePath, "1: 2 (10, 3 (5)\n2: 3 (1)");

        var exeption3 = Assert.Throws<InvalidOperationException>(() => new ReadFile(this.testFilePath));
        Assert.That(exeption3.Message, Does.Contain(this.testFilePath));

        File.WriteAllText(this.testFilePath, "1:  (10), 3 (5)\n2: 3 (1)");

        var exeption4 = Assert.Throws<InvalidOperationException>(() => new ReadFile(this.testFilePath));
        Assert.That(exeption4.Message, Does.Contain(this.testFilePath));

        File.WriteAllText(this.testFilePath, "1: \n2: 3 (1)");

        var exeption5 = Assert.Throws<InvalidOperationException>(() => new ReadFile(this.testFilePath));
        Assert.That(exeption5.Message, Does.Contain(this.testFilePath));

        File.WriteAllText(this.testFilePath, "\n2: 3 (1)");

        var exeption6 = Assert.Throws<InvalidOperationException>(() => new ReadFile(this.testFilePath));
        Assert.That(exeption6.Message, Does.Contain(this.testFilePath));
    }

    [Test]
    public void TestAlgoritmPrima()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (1)\n2: 3 (5)");
        var file = new ReadFile(this.testFilePath);
        var algoritm = new Configuration(file);
        var result = algoritm.ResultConfiguration();

        Assert.That(result[1][2], Is.EqualTo(10));
        Assert.That(result[2][3], Is.EqualTo(5));
        Assert.That(!result.ContainsKey(3));

        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n4: 5 (1)");
        file = new ReadFile(this.testFilePath);
        algoritm = new Configuration(file);
        result = algoritm.ResultConfiguration();

        Assert.That(result[1][2], Is.EqualTo(10));
        Assert.That(result[2][3], Is.EqualTo(5));
        Assert.That(!result.ContainsKey(3));
    }
}

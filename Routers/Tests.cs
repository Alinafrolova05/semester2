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
    public bool AddOriginalNumbers()
    {
        File.WriteAllText(TestFilePath, "1: 2 (10), 3 (5)\r\n2: 3 (1)");
        return true;
    }
}

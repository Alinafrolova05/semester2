using NUnit.Framework;
using LZW;

namespace LZW.Tests;

public class Tests
{
    private string filePath;
    private Tree tree;

    [SetUp]
    public void Setup()
    {
        filePath = Path.Combine(Path.GetTempPath(), "testfile.txt");
        tree = new ();
    }

    [Test]
    public void Test()
    {
        File.WriteAllText(filePath, "abracadabra");

        tree.Compress("filePath.txt");
        tree.Decompress("filePath.zipped");

        string result =File.ReadAllText(filePath);
        Assert.That(result, Is.EqualTo("abracadabra"));
    }
}

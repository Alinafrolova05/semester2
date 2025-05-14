using NUnit.Framework;
using MyLinq;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test()
    {
        IEnumerable<int> newSeq = MyClass.GetPrimes().Take(10);
        int[] check = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        int index = 0;
        foreach (int i in newSeq)
        {
            Assert.That(check[index], Is.EqualTo(i));
            index++;
        }

        newSeq = MyClass.GetPrimes().Skip(5).Take(10);
        index = 5;
        foreach (int i in newSeq)
        {
            Assert.That(check[index], Is.EqualTo(i));
            index++;
        }

        newSeq = MyClass.GetPrimes().Skip(-5).Take(-10);
        Assert.That(newSeq.Any(), Is.False);

        newSeq = MyClass.GetPrimes().Take(5).Skip(10);
        Assert.That(newSeq.Any(), Is.False);
    }
}

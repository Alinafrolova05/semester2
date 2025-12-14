// <copyright file="Test.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ControlWork;

public class Tests
{
    private MyList<int> list;
    private NullCounter<int> nullCounter;

    [SetUp]
    public void Setup()
    {
        this.list = new MyList<int>();
        this.nullCounter = new NullCounter<int>();
    }

    [Test]
    public void TestMyList()
    {
        this.list.Add(1);
        this.list.Add(2);
        this.list.Add(45);
        this.list.Add(-27);

        int[] expectedArray = { 1, 2, 45, -27 };
        int index = 0;

        foreach (var item in this.list)
        {
            Assert.That(item, Is.EqualTo(expectedArray[index]));
            index++;
        }
    }

    [Test]
    public void TestNullListNullCounter()
    {
        this.list = null!;
        Assert.Throws<ArgumentNullException>(() => this.nullCounter.CountNulls(this.list!));
    }

    [Test]
    public void TestWithNullsNullCounter()
    {
        this.list.Add(0);
        this.list.Add(39);
        this.list.Add(0);
        this.list.Add(127);
        this.list.Add(243);
        this.list.Add(-363);
        this.list.Add(0);

        Assert.That(this.nullCounter.CountNulls(this.list), Is.EqualTo(3));
    }

    [Test]
    public void TestWithoutNullsNullCounter()
    {
        this.list.Add(-1);
        this.list.Add(100);
        this.list.Add(-363);

        Assert.That(this.nullCounter.CountNulls(this.list), Is.EqualTo(0));
    }
}

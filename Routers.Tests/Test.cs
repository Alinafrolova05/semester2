// <copyright file="Test.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

namespace TestAlgorithm;

using Routers;

/// <summary>
/// Class for testing the functionality of the FileReader and Configuration classes.
/// </summary>
public class Test
{
    private readonly string testFilePath;
    private FileReader file;
    private Configuration algoritm;
    private Dictionary<int, Dictionary<int, int>> result;

    /// <summary>
    /// Setup method that initializes the FileReader and Configuration instances before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        this.file = new FileReader(this.testFilePath);
        this.algoritm = new Configuration(this.file);
        this.result = this.algoritm.ResultConfiguration();
    }

    /// <summary>
    /// Test case to verify that simple numbers are added correctly.
    /// </summary>
    [Test]
    public void AddSimpleNumbers()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2: 3 (1)");

        var file = new FileReader(this.testFilePath);
        var algoritm = new Configuration(file);
        var result = algoritm.ResultConfiguration();

        Assert.That(result[1][2], Is.EqualTo(10));
        Assert.That(result[1][3], Is.EqualTo(5));
        Assert.That(!result.ContainsKey(2));
    }

    /// <summary>
    /// Test case to validate the file reading functionality and error handling.
    /// </summary>
    [Test]
    public void TestReadFile()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2 3 (1)");

        var exeption1 = Assert.Throws<ArgumentNullException>(() => new FileReader(this.testFilePath));
        Assert.That(exeption1.Message, Does.Contain(this.testFilePath));

        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2: 3 1)");

        var exeption2 = Assert.Throws<InvalidOperationException>(() => new FileReader(this.testFilePath));
        Assert.That(exeption2.Message, Does.Contain(this.testFilePath));

        File.WriteAllText(this.testFilePath, "1: 2 (10, 3 (5)\n2: 3 (1)");

        var exeption3 = Assert.Throws<InvalidOperationException>(() => new FileReader(this.testFilePath));
        Assert.That(exeption3.Message, Does.Contain(this.testFilePath));

        File.WriteAllText(this.testFilePath, "1:  (10), 3 (5)\n2: 3 (1)");

        var exeption4 = Assert.Throws<InvalidOperationException>(() => new FileReader(this.testFilePath));
        Assert.That(exeption4.Message, Does.Contain(this.testFilePath));

        File.WriteAllText(this.testFilePath, "1: \n2: 3 (1)");

        var exeption5 = Assert.Throws<InvalidOperationException>(() => new FileReader(this.testFilePath));
        Assert.That(exeption5.Message, Does.Contain(this.testFilePath));

        File.WriteAllText(this.testFilePath, "\n2: 3 (1)");

        var exeption6 = Assert.Throws<InvalidOperationException>(() => new FileReader(this.testFilePath));
        Assert.That(exeption6.Message, Does.Contain(this.testFilePath));
    }

    /// <summary>
    /// Test case for validating the algorithm's functionality with valid input.
    /// </summary>
    [Test]
    public void TestAlgoritmPrima()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (1)\n2: 3 (5)");
        var file = new FileReader(this.testFilePath);
        var algoritm = new Configuration(file);
        var result = algoritm.ResultConfiguration();

        Assert.That(result[1][2], Is.EqualTo(10));
        Assert.That(result[2][3], Is.EqualTo(5));
        Assert.That(!result.ContainsKey(3));

        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n4: 5 (1)");
        file = new FileReader(this.testFilePath);
        algoritm = new Configuration(file);
        result = algoritm.ResultConfiguration();

        Assert.That(result[1][2], Is.EqualTo(10));
        Assert.That(result[2][3], Is.EqualTo(5));
        Assert.That(!result.ContainsKey(3));
    }
}

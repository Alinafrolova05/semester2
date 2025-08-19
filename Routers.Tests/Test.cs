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
    private readonly string testFilePath = "Text.txt";
    private FileReader file;
    private Configuration algorithm;
    private Dictionary<int, Dictionary<int, int>> result;

    /// <summary>
    /// Setup method that initializes the FileReader and Configuration instances before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2: 3 (1)");
        this.file = new FileReader(this.testFilePath);
        this.algorithm = new Configuration(this.file);
        this.result = this.algorithm.ResultConfiguration();
    }

    /// <summary>
    /// Test case to verify that simple numbers are added correctly.
    /// </summary>
    [Test]
    public void AddSimpleNumbers()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2: 3 (1)");

        var file = new FileReader(this.testFilePath);
        var algorithm = new Configuration(file);
        var result = algorithm.ResultConfiguration();

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

        var exception1 = Assert.Throws<InvalidOperationException>(() => new FileReader(this.testFilePath));
        Assert.That(exception1.Message, Does.Contain("The string does not contain the character ':'."));

        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2: 3 1)");

        var exception2 = Assert.Throws<InvalidOperationException>(() => new FileReader(this.testFilePath));
        Assert.That(exception2.Message, Does.Contain("The string does not contain the character '('."));

        File.WriteAllText(this.testFilePath, "1: 2 (10, 3 (5)\n2: 3 (1)");

        var exception3 = Assert.Throws<InvalidOperationException>(() => new FileReader(this.testFilePath));
        Assert.That(exception3.Message, Does.Contain("Bandwidth is not a number."));

        File.WriteAllText(this.testFilePath, "1:  (10), 3 (5)\n2: 3 (1)");

        var exception4 = Assert.Throws<InvalidOperationException>(() => new FileReader(this.testFilePath));
        Assert.That(exception4.Message, Does.Contain("The graph number is not a number."));

        File.WriteAllText(this.testFilePath, "1: \n2: 3 (1)");

        var exception5 = Assert.Throws<InvalidOperationException>(() => new FileReader(this.testFilePath));
        Assert.That(exception5.Message, Does.Contain("The string does not contain the character '('."));

        File.WriteAllText(this.testFilePath, "\n2: 3 (1)");

        var exception6 = Assert.Throws<InvalidOperationException>(() => new FileReader(this.testFilePath));
        Assert.That(exception6.Message, Does.Contain("The string does not contain the character ':'."));
    }

    /// <summary>
    /// Test case for validating the algorithm's functionality with valid input.
    /// </summary>
    [Test]
    public void TestAlgorithmPrima()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (1)\n2: 3 (5)");
        var file = new FileReader(this.testFilePath);
        var algorithm = new Configuration(file);
        var result = algorithm.ResultConfiguration();

        Assert.That(result[1][2], Is.EqualTo(10));
        Assert.That(result[2][3], Is.EqualTo(5));
        Assert.That(!result.ContainsKey(3));

        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n4: 5 (1)");
        file = new FileReader(this.testFilePath);
        algorithm = new Configuration(file);
        result = algorithm.ResultConfiguration();

        Assert.That(result[1][2], Is.EqualTo(10));
        Assert.That(result[1][3], Is.EqualTo(5));
        Assert.That(!result.ContainsKey(3));
    }
}

// <copyright file="Test.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

using Routers;

/// <summary>
/// Class for testing the functionality of the FileReader and Configuration classes.
/// </summary>
public class Test
{
    private readonly string testFilePath = "Text.txt";

    /// <summary>
    /// Cleanup method to delete test file after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        if (File.Exists(this.testFilePath))
        {
            File.Delete(this.testFilePath);
        }
    }

    /// <summary>
    /// Test case to verify that simple numbers are added correctly.
    /// </summary>
    [Test]
    public void AddSimpleNumbers()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2: 3 (1)");

        FileReader file = new(this.testFilePath);
        Dictionary<int, Dictionary<int, int>> resultGraph = file.NetworkSegmentsGraph;

        Assert.That(resultGraph[1][2], Is.EqualTo(10));
        Assert.That(resultGraph[1][3], Is.EqualTo(5));
        Assert.That(resultGraph.ContainsKey(2));
    }

    /// <summary>
    /// Test case to validate the file reading functionality and error handling.
    /// </summary>
    [Test]
    public void TestReadFile()
    {
        // Test missing colon
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2 3 (1)");
        var exception1 = Assert.Throws<InvalidDataException>(() => new FileReader(this.testFilePath));
        Assert.That(exception1.Message, Does.Contain("Line must contain a colon separator"));

        // Test missing parenthesis
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2: 3 1)");
        var exception2 = Assert.Throws<InvalidDataException>(() => new FileReader(this.testFilePath));
        Assert.That(exception2.Message, Does.Contain("Invalid connection format"));

        // Test invalid weight format
        File.WriteAllText(this.testFilePath, "1: 2 (invalid), 3 (5)\n2: 3 (1)");
        var exception3 = Assert.Throws<InvalidDataException>(() => new FileReader(this.testFilePath));
        Assert.That(exception3.Message, Does.Contain("Invalid weight value"));

        // Test empty target node
        File.WriteAllText(this.testFilePath, "1:  (10), 3 (5)\n2: 3 (1)");
        var exception4 = Assert.Throws<InvalidDataException>(() => new FileReader(this.testFilePath));
        Assert.That(exception4.Message, Does.Contain("Invalid target node"));

        // Test empty connections
        File.WriteAllText(this.testFilePath, "1: \n2: 3 (1)");
        var file = new FileReader(this.testFilePath);
        Assert.That(file, Is.Not.Null);

        // Test empty line
        File.WriteAllText(this.testFilePath, "\n2: 3 (1)");
        var exception6 = Assert.Throws<InvalidDataException>(() => new FileReader(this.testFilePath));
        Assert.That(exception6.Message, Does.Contain("Line 1 is empty."));

        // Test file not found
        var exception7 = Assert.Throws<FileNotFoundException>(() => new FileReader("nonexistent.txt"));
        Assert.That(exception7.Message, Does.Contain("File not found"));

        // Test null file path
        var exception8 = Assert.Throws<ArgumentNullException>(() => new FileReader(null));
        Assert.That(exception8.Message, Does.Contain("File path cannot be null or empty"));
    }

    /// <summary>
    /// Test case for verifying bidirectional connections are created.
    /// </summary>
    [Test]
    public void TestBidirectionalConnections()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10)\n2: 3 (5)");
        FileReader file = new(this.testFilePath);
        var graph = file.NetworkSegmentsGraph;

        Assert.That(graph[1].ContainsKey(2));
        Assert.That(graph[2].ContainsKey(1));
        Assert.That(graph[2].ContainsKey(3));
        Assert.That(graph[3].ContainsKey(2));

        Assert.That(graph[1][2], Is.EqualTo(10));
        Assert.That(graph[2][1], Is.EqualTo(10));
        Assert.That(graph[2][3], Is.EqualTo(5));
        Assert.That(graph[3][2], Is.EqualTo(5));
    }

    /// <summary>
    /// Test case for negative weight validation.
    /// </summary>
    [Test]
    public void TestNegativeWeightValidation()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (-5)");
        var exception = Assert.Throws<InvalidDataException>(() => new FileReader(this.testFilePath));
        Assert.That(exception.Message, Does.Contain("Invalid weight value"));
    }

    /// <summary>
    /// Test case for zero weight validation.
    /// </summary>
    [Test]
    public void TestZeroWeightValidation()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (0)");
        var exception = Assert.Throws<InvalidDataException>(() => new FileReader(this.testFilePath));
        Assert.That(exception.Message, Does.Contain("Invalid weight value"));
    }

    /// <summary>
    /// Test case for ConfigurationGetter constructor validation.
    /// </summary>
    [Test]
    public void TestConfigurationGetterConstructor()
    {
        Assert.That(() => new ConfigurationGetter(null), Throws.ArgumentNullException);

        Assert.That(() => new ConfigurationGetter(string.Empty), Throws.ArgumentNullException);

        Assert.That(() => new ConfigurationGetter("   "), Throws.ArgumentNullException);

        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2: 3 (1)");
        Assert.That(() => new ConfigurationGetter(this.testFilePath), Throws.Nothing);
    }

    /// <summary>
    /// Test case for GetConfiguration method with connected graph.
    /// </summary>
    [Test]
    public void TestGetConfigurationWithConnectedGraph()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10), 3 (5)\n2: 3 (1)");

        ConfigurationGetter configGetter = new(this.testFilePath);
        configGetter.GetConfiguration();

        Assert.That(Environment.ExitCode, Is.EqualTo(0));
    }

    /// <summary>
    /// Test case for GetConfiguration method with disconnected graph.
    /// </summary>
    [Test]
    public void TestGetConfigurationWithDisconnectedGraph()
    {
        File.WriteAllText(this.testFilePath, "1: 2 (10)\n3: 4 (5)");

        ConfigurationGetter configGetter = new(this.testFilePath);
        configGetter.GetConfiguration();

        Assert.That(Environment.ExitCode, Is.EqualTo(-1));
    }

    /// <summary>
    /// Test case for GetConfiguration method with empty graph.
    /// </summary>
    [Test]
    public void TestGetConfigurationWithEmptyGraph()
    {
        File.WriteAllText(this.testFilePath, string.Empty);

        ConfigurationGetter configGetter = new(this.testFilePath);

        Assert.That(() => configGetter.GetConfiguration(), Throws.Nothing);
    }
}

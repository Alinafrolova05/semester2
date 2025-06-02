// <copyright file="Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW.Tests;

using LZW;
using NUnit.Framework;

/// <summary>
/// Tests LZW.
/// </summary>
public class Tests
{
    private readonly NewFile tree = new();
    private string filePath;

    /// <summary>
    /// Sets up a new file.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        this.filePath = Path.Combine(Path.GetTempPath(), "testfile.txt");
    }

    /// <summary>
    /// This is a simple test.
    /// </summary>
    [Test]
    public void TestText()
    {
        File.WriteAllText(this.filePath, "abracadabra");

        this.tree.ChangeFile("filePath.txt", "-c");
        this.tree.ChangeFile("filePath.zipped", "-u");

        string result = File.ReadAllText(this.filePath);
        Assert.That(result, Is.EqualTo("abracadabra"));
    }

    /// <summary>
    /// Tests LZW on binary file.
    /// </summary>
    [Test]
    public void TestBinFile()
    {
        File.WriteAllText(this.filePath, "01000111010101");

        this.tree.ChangeFile("filePath.txt", "-c");
        this.tree.ChangeFile("filePath.zipped", "-u");

        string result = File.ReadAllText(this.filePath);
        Assert.That(result, Is.EqualTo("01000111010101"));
    }
}

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
    private readonly BorLZW tree = new();
    private string filePathTxt = Path.Combine(Path.GetTempPath(), "testfile.txt");
    private string filePathBin = Path.Combine(Path.GetTempPath(), "testfile.bin");

    /// <summary>
    /// This is a simple test.
    /// </summary>
    [Test]
    public void TestText()
    {
        File.WriteAllText(this.filePathTxt, "abracadabra");

        this.tree.Compress("filePath.txt");
        this.tree.Decompress("filePath.zipped");

        string result = File.ReadAllText(this.filePathTxt);
        Assert.That(result, Is.EqualTo("abracadabra"));
    }

    /// <summary>
    /// Tests LZW on binary file.
    /// </summary>
    [Test]
    public void TestBinFile()
    {
        File.WriteAllText(this.filePathBin, "01000111010101");

        this.tree.Compress("filePath.bin");
        this.tree.Decompress("filePath.zipped");

        string result = File.ReadAllText(this.filePathBin);
        Assert.That(result, Is.EqualTo("01000111010101"));
    }
}

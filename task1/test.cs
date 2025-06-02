// <copyright file="Test.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace YourProject.Tests;

#pragma warning disable CS0649

using ChangeTheString;
using NUnit.Framework;

/// <summary>
/// Test converting.
/// </summary>
[TestFixture]
public class Test
{
    private readonly ConvertTheString convertStr;

    /// <summary>
    /// This is a simple test with tree examples.
    /// </summary>
    [Test]
    public void SimpleTest()
    {
        string str1 = "abacaba$";
        string str2 = "abracadabra$";
        string str3 = "hello$";

        using (Assert.EnterMultipleScope())
        {
            Assert.That(this.convertStr.ToConvert(str1), Is.EqualTo("abc$baaa"));
            Assert.That(this.convertStr.ToConvert(str2), Is.EqualTo("ard$rcaaaabb"));
            Assert.That(this.convertStr.ToConvert(str3), Is.EqualTo("oh$ell"));
        }
    }
}

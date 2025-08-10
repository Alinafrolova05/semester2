// <copyright file="test.cs" company="Frolova Alina">
// Copyright (c) Frolova Alina. All rights reserved.
// </copyright>

namespace YourProject.Tests;

#pragma warning disable CS0649

using BwtAlgorithm;
using NUnit.Framework;

/// <summary>
/// Test converting.
/// </summary>
[TestFixture]
public class Test
{
    private readonly BwtResult convertStr;

    /// <summary>
    /// This is a simple test with tree examples.
    /// </summary>
    [Test]
    public void SimpleTest()
    {
        string str1 = "abacaba";
        string str2 = "abracadabra";
        string str3 = "hello";

        using (Assert.EnterMultipleScope())
        {
            Assert.That(this.convertStr.Bwt(str1), Is.EqualTo("bcabaaa"));
            Assert.That(this.convertStr.Bwt(str2), Is.EqualTo("rdarcaaaabb"));
            Assert.That(this.convertStr.Bwt(str3), Is.EqualTo("hoell"));

            Assert.That(this.convertStr.ToDeconvertFromBwt("bcabaaa"), Is.EqualTo(str1));
            Assert.That(this.convertStr.ToDeconvertFromBwt("rdarcaaaabb"), Is.EqualTo(str2));
            Assert.That(this.convertStr.ToDeconvertFromBwt("hoell"), Is.EqualTo(str3));
        }
    }
}

// <copyright file="test.cs" company="Frolova Alina">
// Copyright (c) Frolova Alina. All rights reserved.
// </copyright>

namespace BwtAlgorithm;

#pragma warning disable CS0649

using BwtAlgorithm;

/// <summary>
/// Test converting.
/// </summary>
public class Test
{
    private string str1 = "abacaba";
    private string str2 = "abracadabra";
    private string str3 = "hello";
    private readonly BwtResult convertStr = new BwtResult();

    /// <summary>
    /// This is a simple test with tree examples.
    /// </summary>
    /// <returns> True or not. </returns>
    public bool SimpleTest()
    {
        return this.TestConverting() && this.TestDeconverting();
    }

    private bool TestConverting()
    {
        if (this.convertStr.Bwt(this.str1) != ("bcabaaa", 5) ||
        this.convertStr.Bwt(this.str2) != ("rdarcaaaabb", 6) ||
        this.convertStr.Bwt(this.str3) != ("hoell", 0))
        {
            return false;
        }

        return true;
    }

    private bool TestDeconverting()
    {
        if (this.convertStr.ToDeconvertFromBwt("bcabaaa", 5) != this.str1 ||
        this.convertStr.ToDeconvertFromBwt("rdarcaaaabb", 6) != this.str2 ||
        this.convertStr.ToDeconvertFromBwt("hoell", 0) != this.str3)
        {
            return false;
        }

        return true;
    }
}

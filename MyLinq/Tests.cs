// <copyright file="Tests.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

using MyLinq;

/// <summary>
/// Unit tests.
/// </summary>
public class Tests
{
    private IEnumerable<int> newSeq = MyClass.GetPrimes().Take(10);
    private int[] check = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
    private int index = 0;

    /// <summary>
    /// Runs all tests and returns true if all tests passed.
    /// </summary>
    /// <returns>True if all tests passed.</returns>
    public bool RunTests()
    {
        return this.TestGetFirstTenPrimes() && this.TestGetPrimesAfterSkippingFive() &&
               this.TestSkipNegativeValues() && this.TestTakeAndSkip();
    }

    private bool TestGetFirstTenPrimes()
    {
        foreach (int i in this.newSeq)
        {
            if (this.check[this.index] != i)
            {
                return false;
            }

            this.index++;
        }

        return true;
    }

    private bool TestGetPrimesAfterSkippingFive()
    {
        this.newSeq = MyClass.GetPrimes().Skip(5).Take(5);
        this.index = 5;

        foreach (int i in this.newSeq)
        {
            if (this.index >= this.check.Length || this.check[this.index] != i)
            {
                return false;
            }

            this.index++;
        }

        return true;
    }

    private bool TestSkipNegativeValues()
    {
        this.newSeq = MyClass.GetPrimes().Skip(-5).Take(-10);
        return !this.newSeq.Any();
    }

    private bool TestTakeAndSkip()
    {
        this.newSeq = MyClass.GetPrimes().Take(5).Skip(10);
        return !this.newSeq.Any();
    }
}

// <copyright file="MyClass.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

namespace MyLinq;

/// <summary>
/// Provides LINQ-like methods.
/// </summary>
public static class MyClass
{
    /// <summary>
    /// Generates an infinite sequence of prime numbers.
    /// </summary>
    /// <returns>An enumerable collection of prime numbers.</returns>
    public static IEnumerable<int> GetPrimes()
    {
        for (var i = 2; true; i++)
        {
            bool isPrime = true;
            for (var j = 2; i >= j * j; ++j)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                yield return i;
            }
        }
    }

    /// <summary>
    /// Returns the first n elements of the provided sequence.
    /// </summary>
    /// <param name="seq">The input sequence of integers.</param>
    /// <param name="n">The number of elements to take from the sequence.</param>
    /// <returns>An enumerable collection containing the first n elements.</returns>
    public static IEnumerable<int> Take(this IEnumerable<int> seq, int n)
    {
        int count = 1;
        foreach (var i in seq)
        {
            if (count > n)
            {
                break;
            }

            count++;
            yield return i;
        }
    }

    /// <summary>
    /// Skips the first n elements of the provided sequence and returns the remaining elements.
    /// </summary>
    /// <param name="seq">The input sequence of integers.</param>
    /// <param name="n">The number of elements to skip.</param>
    /// <returns>An enumerable collection containing the elements after skipping the first n elements.</returns>
    public static IEnumerable<int> Skip(this IEnumerable<int> seq, int n)
    {
        int count = 1;
        foreach (var i in seq)
        {
            if (count > n)
            {
                yield return i;
            }

            count++;
        }
    }
}

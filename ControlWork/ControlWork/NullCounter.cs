// <copyright file="NullCounter.cs" company="Alinafrolova05">
// Copyright (c) Alinafrolova05. All rights reserved.
// </copyright>

namespace ControlWork;

/// <summary>
/// Provides utility methods for counting null elements in collections.
/// </summary>
/// <typeparam name="T">The type of elements in the collection.</typeparam>
public class NullCounter<T> : INullCounter<T>
{
    /// <summary>
    /// Determines whether the specified value is considered null for the current type.
    /// </summary>
    /// <param name="value">The value to check for null.</param>
    /// <returns>true if the value is null; otherwise, false.</returns>
    public bool IsNull(T value) => value switch
    {
        null => true,

        byte b when b == 0 => true,
        int i when i == 0 => true,

        float f when f == 0 => true,
        double d when d == 0 => true,
        decimal dec when dec == 0 => true,

        bool b when b == false => true,

        char c when c == '\0' => true,

        string s when string.IsNullOrEmpty(s) => true,

        _ => false,
    };

    /// <summary>
    /// Counts the number of null elements in the specified list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to search for null elements.</param>
    /// <returns>The number of null elements found in the list.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the list parameter is null.</exception>
    public int CountNulls(MyList<T> list)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "List cannot be null");
        }

        return list.Count(element => this.IsNull(element));
    }
}

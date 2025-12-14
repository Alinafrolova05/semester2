// <copyright file="MyList.cs" company="Alinafrolova05">
// Copyright (c) Alinafrolova05. All rights reserved.
// </copyright>

namespace ControlWork;

using System.Collections;

/// <summary>
/// Represents a generic list implementation with null element tracking capabilities.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class MyList<T> : IMyList<T>, IEnumerable<T>
{
    private T[] array = new T[256];
    private int size;

    /// <summary>
    /// Adds an element to the end of the list.
    /// </summary>
    /// <param name="value">The element to add to the list.</param>
    public void Add(T value)
    {
        if (this.size == this.array.Length)
        {
            Array.Resize(ref this.array, this.array.Length * 2);
        }

        this.array[this.size++] = value;
    }

    /// <summary>
    /// Returns a generic enumerator that iterates through all elements in the list.
    /// </summary>
    /// <returns>An <see cref="IEnumerator{T}"/> that can be used to iterate through the collection.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.size; i++)
        {
            yield return this.array[i];
        }
    }

    /// <summary>
    /// Returns a non-generic enumerator that iterates through all elements in the list.
    /// Explicit implementation of the <see cref="IEnumerable"/> interface.
    /// </summary>
    /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

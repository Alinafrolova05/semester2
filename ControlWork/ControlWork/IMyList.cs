// <copyright file="IList.cs" company="Alinafrolova05">
// Copyright (c) Alinafrolova05. All rights reserved.
// </copyright>

namespace ControlWork;

/// <summary>
/// Interface.
/// </summary>
/// <typeparam name="T"> n. </typeparam>
public interface IMyList<T>
{
    /// <summary>
    /// Adds an element to the end of the list.
    /// </summary>
    /// <param name="value">The element to add to the list.</param>
    void Add(T value);
}

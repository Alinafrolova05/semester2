// <copyright file="INullCounter.cs" company="Alinafrolova05">
// Copyright (c) Alinafrolova05. All rights reserved.
// </copyright>

namespace ControlWork;

/// <summary>
/// Class, that determining if a value should be considered null. Has an enumerator.
/// </summary>
/// <typeparam name="T">The type of value to check for null.</typeparam>
internal interface INullCounter<T>
{
    /// <summary>
    /// Determines whether the specified value is considered null for the current type.
    /// </summary>
    /// <param name="value"> The value to check for null. </param>
    /// <returns> true if the value is null; otherwise, false. </returns>
    bool IsNull(T value);
}

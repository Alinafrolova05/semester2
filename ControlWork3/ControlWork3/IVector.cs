// <copyright file="IVector.cs" company="Alinafrolova05">
// Copyright (c) Alinafrolova05. All rights reserved.
// </copyright>

namespace ControlWork3;

/// <summary>
/// Interface for vector.
/// </summary>
internal interface IVector
{
    /// <summary>
    /// Adds vectors.
    /// </summary>
    /// <param name="list"> List is vector.</param>
    public void Add(List<int> list);

    /// <summary>
    /// Subtract vectors.
    /// </summary>
    /// <param name="list"> List is vector. </param>
    public void Subtract(List<int> list);

    /// <summary>
    /// Scalar multiplicate vectors.
    /// </summary>
    /// <param name="list"> List is vector. </param>
    /// <returns> The result of Scalar multiplication. </returns>
    public int ScalarMultiplication(List<int> list);

    /// <summary>
    /// Checks the vector if it is null.
    /// </summary>
    /// <param name="list"> List is vector. </param>
    /// <returns>  if vector is null, returns true; otherwise, false. </returns>
    public bool IsZero(List<int> list);

    /// <summary>
    /// Gets vector in list.
    /// </summary>
    /// <returns> Vector in list.</returns>
    public List<int> GetVector();
}

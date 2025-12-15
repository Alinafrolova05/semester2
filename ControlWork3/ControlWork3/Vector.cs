// <copyright file="Vector.cs" company="Alinafrolova05">
// Copyright (c) Alinafrolova05. All rights reserved.
// </copyright>

namespace ControlWork3;

using System.Linq;

/// <summary>
/// Represents a vector implemented using a dictionary with indices and values of type int.
/// Used for storing elements with associated indices and values.
/// </summary>
public class Vector : IVector
{
    private Dictionary<int, int> vector;
    private int size;

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector"/> class.
    /// </summary>
    public Vector()
    {
        this.vector = new();
    }

    /// <summary>
    /// Adds vectors.
    /// </summary>
    /// <param name="list"> List is vector.</param>
    public void Add(List<int> list)
    {
        if (!this.IsEqualLength(list))
        {
            throw new ArgumentException();
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == 0)
            {
                continue;
            }
            else
            {
                if (this.vector.ContainsKey(i))
                {
                    this.vector[i] += list[i];
                }
                else
                {
                    this.vector.Add(i, list[i]);
                }
            }
        }
    }

    /// <summary>
    /// Subtract vectors.
    /// </summary>
    /// <param name="list"> List is vector. </param>
    public void Subtract(List<int> list)
    {
        if (!this.IsEqualLength(list))
        {
            throw new ArgumentException();
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == 0)
            {
                continue;
            }
            else
            {
                if (this.vector.ContainsKey(i))
                {
                    this.vector[i] -= list[i];
                }
                else
                {
                    this.vector.Add(i, -list[i]);
                }
            }
        }
    }

    /// <summary>
    /// Scalar multiplicate vectors.
    /// </summary>
    /// <param name="list"> List is vector. </param>
    /// <returns> The result of Scalar multiplication. </returns>
    public int ScalarMultiplication(List<int> list)
    {
        if (!this.IsEqualLength(list))
        {
            throw new ArgumentException();
        }

        int result = 0;

        for (int i = 0; i < list.Count; i++)
        {
            if (this.vector.ContainsKey(i))
            {
                result += this.vector[i] * list[i];
            }
        }

        return result;
    }

    /// <summary>
    /// Checks the vector if it is null.
    /// </summary>
    /// <param name="list"> List is vector. </param>
    /// <returns>  if vector is null, returns true; otherwise, false. </returns>
    public bool IsZero(List<int> list) => list.Count(x => x != 0) == 0;

    /// <summary>
    /// Gets vector in list.
    /// </summary>
    /// <returns> Vector in list.</returns>
    public List<int> GetVector()
    {
        List<int> vectorList = new List<int>(this.size);

        for (int i = 0; i < this.size; ++i)
        {
            if (this.vector.ContainsKey(i))
            {
                vectorList.Add(this.vector[i]);
            }
            else
            {
                vectorList.Add(0);
            }
        }

        return vectorList;
    }

    private bool IsEqualLength(List<int> list)
    {
        if (this.size == 0)
        {
            this.size = list.Count;
            return true;
        }

        return this.size == list.Count;
    }
}

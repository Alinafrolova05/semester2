// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WorkControl;

/// <summary>
/// Represents an element to add in queue.
/// </summary>
public class Node<T>
{
    private int priority;

    private T value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Node{T}"/> class.
    /// </summary>
    /// <param name="priority"> Priority of element to add. </param>
    /// <param name="value"> Value of element to add. </param>
    public Node(int priority, T value)
    {
        this.priority = priority;
        this.value = value;
    }

    /// <summary>
    /// Gets priority of element.
    /// </summary>
    /// <returns> Priority. </returns>
    public int GetPriority()
    {
        return this.priority;
    }

    /// <summary>
    /// Gets value of element.
    /// </summary>
    /// <returns> Value. </returns>
    public T GetValue()
    {
        return this.value;
    }
}
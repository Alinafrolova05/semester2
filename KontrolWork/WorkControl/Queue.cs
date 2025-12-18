// <copyright file="Queue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WorkControl;

/// <summary>
/// Interface for a queue.
/// </summary>
internal class Queue : IQueue
{
    private int[] array;

    /// <summary>
    /// Initializes a new instance of the <see cref="Queue"/> class.
    /// </summary>
    public Queue()
    {
        this.array = new int[0];
    }

    /// <summary>
    /// Adds an item to the queue.
    /// </summary>
    public void Enqueue()
    {

    }

    /// <summary>
    /// Removes an item from the front of the queue.
    /// </summary>
    public void Dequeue()
    {

    }

    /// <summary>
    /// Checks if the queue is empty.
    /// </summary>
    /// <returns> True if empty, otherwise false. </returns>
    public bool Empty()
    {
        return true;
    }
}

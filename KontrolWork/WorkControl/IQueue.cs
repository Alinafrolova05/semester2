// <copyright file="IQueue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WorkControl;

/// <summary>
/// Interface for queue.
/// </summary>
internal interface IQueue
{
    /// <summary>
    /// Adds an item to the queue.
    /// </summary>
    public void Enqueue();

    /// <summary>
    /// Removes an item from the front of the queue.
    /// </summary>
    public void Dequeue();

    /// <summary>
    /// Checks if the queue is empty.
    /// </summary>
    /// <returns> True if empty, otherwise false. </returns>
    public bool Empty();
}
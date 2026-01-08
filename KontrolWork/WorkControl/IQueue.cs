// <copyright file="IQueue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WorkControl;

/// <summary>
/// Interface for a queue with priority.
/// </summary>
/// <typeparam name="T"> . </typeparam>
internal interface IQueue<T>
{
    /// <summary>
    /// Adds an item to the queue.
    /// </summary>
    /// <param name="priority"> Priority of element to add. </param>
    /// <param name="value"> Value of element to add. </param>
    public void Enqueue(int priority, T value);

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

// <copyright file="Queue.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

namespace ControlWork;

/// <summary>
/// Represents queue.
/// </summary>
public class Queue
{
    private int lengthArray = 10;
    private int startIndex;
    private int index;
    private int[] array;

    /// <summary>
    /// Initializes a new instance of the <see cref="Queue"/> class.
    /// </summary>
    public Queue()
    {
        this.array = new int[this.lengthArray];
    }

    /// <summary>
    /// Adds an element to the end of the queue.
    /// </summary>
    /// <param name="value">The value to be added to the queue.</param>
    public void Enqueue(int value)
    {
        if (this.index >= this.lengthArray)
        {
            Array.Resize(ref this.array, this.lengthArray * 2);
            this.lengthArray *= 2;
        }

        this.array[this.index] = value;
        this.index++;
        this.ChangePosition();
    }

    /// <summary>
    /// Removes and returns the element at the front of the queue.
    /// </summary>
    /// <returns>The value of the dequeued element.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
    public int Dequeue()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        int value = this.array[0];
        for (int i = 1; i < this.index; i++)
        {
            this.array[i - 1] = this.array[i];
        }

        this.index--;
        this.startIndex++;
        return value;
    }

    /// <summary>
    /// Checks if the queue is empty.
    /// </summary>
    /// <returns>True if the queue is empty; otherwise, false.</returns>
    public bool IsEmpty() => this.index == 0;

    private void ChangePosition()
    {
        int positionNow = this.index;
        for (int parent = (this.index - 1) / 2; parent > this.startIndex; parent = (parent - 1) / 2)
        {
            if (this.array[positionNow] > this.array[parent])
            {
                int number = this.array[positionNow];
                this.array[positionNow] = this.array[parent];
                this.array[parent] = number;
            }
            else
            {
                break;
            }
        }
    }
}

// <copyright file="Queue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WorkControl;

/// <summary>
/// Class for a queue with priority.
/// </summary>
public class Queue<T> : IQueue<T>
{
    private Node<T>[] array;
    private int size;

    /// <summary>
    /// Initializes a new instance of the <see cref="Queue{T}"/> class.
    /// </summary>
    public Queue()
    {
        this.array = new Node<T>[256];
    }

    /// <summary>
    /// Adds an item to the queue.
    /// </summary>
    /// <param name="priority"> Priority of element to add. </param>
    /// <param name="value"> Value of element to add. </param>
    public void Enqueue(int priority, T value)
    {
        if (this.size > this.array.Length)
        {
            Array.Resize(ref this.array, this.array.Length * 2);
        }

        Node<T> node = new(priority, value);

        this.array[this.size] = node;

        int i = this.size;
        while (this.array[(i - 1) / 2].GetPriority() >= this.array[i].GetPriority() && i > 0)
        {
            Swap(ref this.array[(i - 1) / 2], ref this.array[i / 2]);
            i = (i - 1) / 2;
        }

        this.size++;
    }

    /// <summary>
    /// Removes an item from the front of the queue.
    /// </summary>
    public void Dequeue()
    {
        if (this.Empty())
        {
            return;
        }

        Swap(ref this.array[0], ref this.array[this.size - 1]);
        this.size--;

        int i = 0;
        while (true)
        {
            int leftChild = (2 * i) + 1;
            int rightChild = (2 * i) + 2;
            int largest = i;

            if (leftChild < this.size && this.array[leftChild].GetPriority() > this.array[largest].GetPriority())
            {
                largest = leftChild;
            }

            if (rightChild < this.size && this.array[rightChild].GetPriority() > this.array[largest].GetPriority())
            {
                largest = rightChild;
            }

            if (largest == i)
            {
                break;
            }

            Swap(ref this.array[i], ref this.array[largest]);
            i = largest;
        }
    }

    /// <summary>
    /// Checks if the queue is empty.
    /// </summary>
    /// <returns> True if empty, otherwise false. </returns>
    public bool Empty() => this.size < 1;

    private static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}

using System.Collections;

namespace ControlWork;

/// <summary>
/// Defines List.
/// </summary>
/// <typeparam name="T"> n. </typeparam>
public class List<T> : IEnumerable<T>
{
    private T[] array;
    private int size;

    /// <summary>
    /// Initializes a new instance of the <see cref="List{T}"/> class.
    /// </summary>
    public List()
    {
        this.array = new T[256];
        this.size = 0;
    }

    /// <summary>
    /// Adds value.
    /// </summary>
    /// <param name="value"> parametor. </param>
    public void Add(T value)
    {
        if (this.size == this.array.Length)
        {
            Array.Resize(ref this.array, this.array.Length * 2);
        }

        this.array[this.size++] = value;
    }

    /// <summary>
    /// Goes in array.
    /// </summary>
    /// <returns> IEnumerator. </returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.size; i++)
        {
            yield return this.array[i];
        }
    }

    /// <summary>
    /// Returns list.
    /// </summary>
    /// <returns> IEnumerator. </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Defines null.
    /// </summary>
    /// <param name="value"> Parametor.</param>
    /// <returns> is Null - true. </returns>
    public bool IsNull(T value) => value == null;
}

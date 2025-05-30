namespace ControlWork2;

/// <summary>
/// Defines List.
/// </summary>
/// <typeparam name="T"> n. </typeparam>
public class List<T>
{
    private T[] array;
    private int size;

    /// <summary>
    /// Initializes a new instance of the <see cref="List{T}"/> class.
    /// </summary>
    public List()
    {
        this.array = new T[256];
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
    /// Gets the current length (capacity) of the list.
    /// </summary>
    /// <returns>The length of the internal array.</returns>
    public int LenghtOfList() => this.size;

    /// <summary>
    /// Retrieves the value at the specified index in the list.
    /// </summary>
    /// <param name="index">The index of the value to retrieve.</param>
    /// <returns>The value at the specified index.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown when the index is out of range.</exception>
    public T GetValue(int index)
    {
        if (index < 0 || index >= this.size)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        return this.array[index];
    }

    /// <summary>
    /// Sets the value at the specified index in the list.
    /// </summary>
    /// <param name="index">The index to set the value at.</param>
    /// <param name="value">The value to set.</param>
    /// <exception cref="IndexOutOfRangeException">Thrown when the index is out of range.</exception>
    public void SetValue(int index, T value)
    {
        if (index < 0 || index >= this.size)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        this.array[index] = value;
    }
}

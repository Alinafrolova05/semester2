namespace ControlWork3;

/// <summary>
/// Represents a vector implemented using a dictionary with indices and values of type int.
/// Used for storing elements with associated indices and values.
/// </summary>
/// <typeparam name="T">Type of the elements in the vector (currently not used and always int).</typeparam>
public class Vector<T>
{
    private Dictionary<int,int> vector;
    private int size;

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector{T}"/> class.
    /// </summary>
    public Vector()
    {
        this.vector = new();
    }

    /// <summary>
    /// Adds an element to the vector with the specified index and value.
    /// </summary>
    /// <param name="key">The index of the element.</param>
    /// <param name="value">The value of the element.</param>
    /// <remarks>
    /// Increases the size counter of the vector.
    /// </remarks>
    public void Add(int key, int value)
    {
        if (this.vector != null)
        {
            this.vector.Add(key, value);
        }

        this.size++;
    }

    /// <summary>
    /// Returns the number of elements added to the vector.
    /// </summary>
    /// <returns>The number of elements.</returns>
    public int GetLenght() => this.size;

    /// <summary>
    /// Checks if an element with the specified index exists in the vector.
    /// </summary>
    /// <param name="key">The index of the element.</param>
    /// <returns><c>true</c> if an element with that index exists; otherwise, <c>false</c>.</returns>
    public bool IsKeyExits(int key)
    {
        if (!this.vector.ContainsKey(key))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Retrieves the value associated with the specified index in the vector.
    /// </summary>
    /// <param name="key">The index of the element.</param>
    /// <returns>The value associated with the specified index.</returns>
    public int GetKey(int key)
    {
        return this.vector[key];
    }

    /// <summary>
    /// Retrieves the value associated with the specified index in the vector.
    /// This method is an alias for <see cref="GetKey(int)"/>.
    /// </summary>
    /// <param name="key">The index of the element.</param>
    /// <returns>The value associated with the specified index.</returns>
    public int GetValue(int key) => this.vector[key];
}

namespace ControlWork3;

/// <summary>
/// Provides operations for performing arithmetic on vectors.
/// </summary>
public static class Operations
{
    /// <summary>
    /// Adds two vectors element-wise and returns a new vector containing the results.
    /// </summary>
    /// <typeparam name="T">The type of elements in the vectors (currently not utilized).</typeparam>
    /// <param name="vector1">The first vector to add.</param>
    /// <param name="vector2">The second vector to add.</param>
    public static Vector<T> Plus<T>(Vector<T> vector1, Vector<T> vector2)
    {
        Vector<T> newVector = new();

        int size = Math.Max(vector1.GetLenght(), vector2.GetLenght());

        int i = 0;
        while (i < size)
        {
            if (vector1.IsKeyExits(i) && vector2.IsKeyExits(i))
            {
                newVector.Add(i, vector1.GetValue(i) + vector2.GetValue(i));
                break;
            }
            else if (vector1.IsKeyExits(i))
            {
                newVector.Add(i, vector1.GetValue(i));
                break;
            }
            else if (vector2.IsKeyExits(i))
            {
                newVector.Add(i, vector1.GetValue(i));
                break;
            }
        }

        return newVector;
    }

    /// <summary>
    /// Subtracts the second vector from the first vector element-wise and returns a new vector containing the results.
    /// </summary>
    /// <typeparam name="T">The type of elements in the vectors (currently not utilized).</typeparam>
    /// <param name="vector1">The vector from which to subtract.</param>
    /// <param name="vector2">The vector to subtract.</param>
    public static Vector<T> Minus<T>(Vector<T> vector1, Vector<T> vector2)
    {
        Vector<T> newVector = new();

        int size = Math.Max(vector1.GetLenght(), vector2.GetLenght());

        int i = 0;
        while (i < size)
        {
            if (vector1.IsKeyExits(i) && vector2.IsKeyExits(i))
            {
                newVector.Add(i, vector1.GetValue(i) - vector2.GetValue(i));
                break;
            }
            else if (vector1.IsKeyExits(i))
            {
                newVector.Add(i, vector1.GetValue(i));
                break;
            }
            else if (vector2.IsKeyExits(i))
            {
                newVector.Add(i, vector1.GetValue(i));
                break;
            }
        }

        return newVector;
    }

    /// <summary>
    /// Multiplies two vectors element-wise and returns a new vector containing the results.
    /// </summary>
    /// <typeparam name="T">The type of elements in the vectors (currently not utilized).</typeparam>
    /// <param name="vector1">The first vector to multiply.</param>
    /// <param name="vector2">The second vector to multiply.</param>
    public static Vector<T> Multiply<T>(Vector<T> vector1, Vector<T> vector2)
    {
        Vector<T> newVector = new();

        int size = Math.Max(vector1.GetLenght(), vector2.GetLenght());

        int i = 0;
        while (i < size)
        {
            if (vector1.IsKeyExits(i) && vector2.IsKeyExits(i))
            {
                newVector.Add(i, vector1.GetValue(i) * vector2.GetValue(i));
                break;
            }
        }

        return newVector;
    }
}

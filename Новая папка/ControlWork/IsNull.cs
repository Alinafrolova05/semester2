namespace ControlWork;

/// <summary>
/// Interface.
/// </summary>
/// <typeparam name="T"> n. </typeparam>
public interface INullChecker<T>
{
    /// <summary>
    /// Adds element.
    /// </summary>
    /// <param name="value"> null. </param>
    void Add(T value);

    /// <summary>
    /// Returns IEnumerator.
    /// </summary>
    /// <returns> IEnumerator. </returns>
    IEnumerator<T> GetEnumerator();

    /// <summary>
    /// Is Null.
    /// </summary>
    /// <param name="item"></param>
    /// <returns> Is null. </returns>
    bool IsNull(T item);
}

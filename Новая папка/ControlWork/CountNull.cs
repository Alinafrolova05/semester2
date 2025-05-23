namespace ControlWork;

/// <summary>
/// Counts null.
/// </summary>
public static class NullCounter
{
    /// <summary>
    /// Counts nulls.
    /// </summary>
    /// <typeparam name="T"> n. </typeparam>
    /// <param name="list"> Name Of List. </param>
    /// <param name="nullChecker"> Interface. </param>
    /// <returns> Number of nulls. </returns>
    public static int CountNulls<T>(List<T> list, INullChecker<T> nullChecker)
    {
        int count = 0;
        foreach (var item in list)
        {
            if (nullChecker.IsNull(item))
            {
                count++;
            }
        }

        return count;
    }
}

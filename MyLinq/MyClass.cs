namespace MyLinq;

/// <summary>
/// 
/// </summary>
public static class MyClass
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<int> GetPrimes()
    {
        for (var i = 1; true; i++)
        {
            bool isPrime = true;
            for (var j = 2; i >= j * j; ++j)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                yield return i;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="seq"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<int> Take(this IEnumerable<int> seq, int n)
    {
        int count = 1;
        foreach (var i in seq)
        {
            if (count > n)
            {
                break;
            }

            count++;
            yield return i;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="seq"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<int> Skip(this IEnumerable<int> seq, int n)
    {
        int count = 0;
        foreach (var i in seq)
        {
            if (count > n)
            {
                yield return i;
            }

            count++;
        }
    }
}

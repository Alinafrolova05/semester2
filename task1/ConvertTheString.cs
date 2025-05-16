namespace ConvertTheString;

/// <summary>
/// Convert the string.
/// </summary>
public class ConvertStr
{
    /// <summary>
    /// Convert the string.
    /// </summary>
    /// <param name="str"> Initial value of string. </param>
    /// <returns> The converted string. </returns>
    public string Result(string str)
    {
        return Compare(str);
    }

    private string Compare(string str)
    {
        List<int> strList = new();
        for (var i = 0; i < str.Length; ++i)
        {
            strList.Add(i);
        }

        List<int> result = new();
        for (var i = 0; i < str.Length; ++i)
        {
            int maxIndex = this.FindIndexOfMaxString(str, strList);
            result.Add((strList[maxIndex] + str.Length - 1) % str.Length);
            strList.RemoveAt(maxIndex);
        }

        result.Reverse();

        string resultStr = string.Empty;
        foreach (var i in result)
        {
            resultStr += str[i];
        }

        return resultStr;
    }

    private int FindIndexOfMaxString(string str, List<int> strList)
    {
        int maxIdx = 0;
        for (int i = 1; i < strList.Count; i++)
        {
            if (this.IsLarger(str, strList[i], strList[maxIdx]))
            {
                maxIdx = i;
            }
        }

        return maxIdx;
    }

    private bool IsLarger(string str, int index1, int index2)
    {
        for (int i = 0; i < str.Length; i++)
        {
            char c1 = str[(index1 + i) % str.Length];
            char c2 = str[(index2 + i) % str.Length];

            if (c1 > c2)
            {
                return true;
            }

            if (c1 < c2)
            {
                return false;
            }
        }

        return false;
    }
}

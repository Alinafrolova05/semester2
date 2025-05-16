namespace LZW;

using System.Linq;

/// <summary>
/// Transforms a string using the Burrows Wheeler algorithm.
/// </summary>
public class BarrowW
{
    /// <summary>
    /// Transforms a string using the Burrows Wheeler algorithm.
    /// </summary>
    /// <param name="str"> Initial value of the string. </param>
    /// <returns> Returns the converted string. </returns>
    public string Result(string str)
    {
        return this.Compare(str);
    }

    private string Compare(string str)
    {
        List<int> strList = new ();
        for (var i = 0; i < str.Length; ++i)
        {
            strList.Add(i);
        }

        List<int> result = new ();
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

    private List<char> InverseСonversion(string sortedStr, string strDecompress)
    {
        List<int> visitedIndexes = new ();
        List<char> resultStr = new ();

        int currentIndex = 0;

        for (var i = 0; i < strDecompress.Length; ++i)
        {
            if (currentIndex >= sortedStr.Length)
            {
                break;
            }

            resultStr.Add(sortedStr[currentIndex]);

            int findIndex = 0;
            while (sortedStr[findIndex] != strDecompress[currentIndex] && visitedIndexes.Contains(findIndex) && findIndex < strDecompress.Length)
            {
                findIndex++;
            }

            if (findIndex >= strDecompress.Length)
            {
                break;
            }
            else
            {
                visitedIndexes.Add(findIndex);
                currentIndex = findIndex;
            }
        }

        resultStr.Reverse();

        return resultStr;
    }
}

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
        string resultStr = string.Empty;
        List<int> resIntStr = this.CompareString(str);
        foreach (var i in resIntStr)
        {
            resultStr += str[i];
        }

        return resultStr;
    }

    private List<int> CompareString(string str)
    {
        List<int> resultStr = new ();
        List<int> resultStr2 = new();

        resultStr.Add(this.FindIndexOfMinString(str, 0, resultStr));
        for (int i = 0; i < str.Length - 1; i++)
        {
            int k = this.FindIndexOfMinString(str, resultStr.Last(), resultStr);

            resultStr.Add((k) % str.Length);
            Console.WriteLine((k + str.Length - 1) % str.Length);
            resultStr2.Add((k + str.Length - 1) % str.Length);


        }

        return resultStr2;
    }

    private int FindIndexOfMinString(string str, int index, List<int> resultStr)
    {
        int currentIndex = 0;
        int checkMaxIndexLenght = 0;

        int indexNext = index + 1;
        for (var j = 0; j < str.Length; ++j)
        {
            if (resultStr.Contains((indexNext + j) % str.Length))
            {
                continue;
            }

            int countLessOrEquel = 0;
            for (var i = 0; i < str.Length; ++i)
            {
                if (str[(index + i) % str.Length] > str[(indexNext + j + i) % str.Length])
                {
                    break;
                }

                countLessOrEquel++;
            }

            if (checkMaxIndexLenght < countLessOrEquel)
            {
                checkMaxIndexLenght = countLessOrEquel;
                currentIndex = (indexNext + j) % str.Length;
            }
        }

        return currentIndex;
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

namespace LZW;

using System.Text;

/// <summary>
/// Transforms a string using the Burrows Wheeler algorithm.
/// </summary>
public class BarrowW
{
    private int originalIndexStart;
    private int originalIndexFinish;

    /// <summary>
    /// Transforms a string using the Burrows Wheeler algorithm.
    /// </summary>
    /// <param name="str"> Initial value of the string. </param>
    /// <returns> Returns the converted string. </returns>
    public string ToConvert(string str)
    {
        return this.Compare(str);
    }

    /// <summary>
    /// Deconverts string.
    /// </summary>
    /// <param name="str"> Value of the converted string. </param>
    /// <returns> Deconverted string. </returns>
    public string ToDeconvert(string str)
    {
        return this.ToDeconvertString(str);
    }

    private string Compare(string originalStr)
    {
        StringBuilder str = new ();
        str.Append(originalStr);
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

        var resultStr = new StringBuilder();
        for (int i = 0; i < result.Count; ++i)
        {
            resultStr.Append(str[result[i]]);
            if (result[i] == 0)
            {
                this.originalIndexStart = i;
            }

            if (result[i] == result.Count - 1)
            {
                this.originalIndexFinish = i;
            }
        }

        return resultStr.ToString();
    }

    private int FindIndexOfMaxString(StringBuilder str, List<int> strList)
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

    private bool IsLarger(StringBuilder str, int index1, int index2)
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

    public string ToDeconvertString(string str)
    {
        Console.WriteLine($"start = {this.originalIndexStart}, finish = {this.originalIndexFinish}");
        char[] strSortedArray = str.ToCharArray();
        Array.Sort(strSortedArray);

        char[] strArray = str.ToCharArray();
        List<char> resultStr = new ();

        List<int> arrayOfIndexes = new ();
        for (int i = 0; i < str.Length; ++i)
        {
            arrayOfIndexes.Add(i);
        }

        this.FindInArray(strArray, strSortedArray, resultStr, arrayOfIndexes, str);

        resultStr.Reverse();
        string result = string.Join(string.Empty, resultStr);
        return result;
    }

    public void FindInArray(char[] strArray, char[] strSortedArray,
        List<char> resultStr, List<int> arrayOfIndexes, string str)
    {
        int index = this.originalIndexStart;

        for (int i = 0; i < str.Length; ++i)
        {
            int nextIndex = 0;
            while (nextIndex < str.Length - 1)
            {
                if (strSortedArray[nextIndex] == resultStr.Last() && arrayOfIndexes.Contains(nextIndex))
                {
                    resultStr.Add(strArray[nextIndex]);
                    arrayOfIndexes.Remove(index);
                    break;
                }

                nextIndex++;
            }
        }
    }

    private string DecompressFromBWT(string bwt)
    {
        int length = bwt.Length;
        int[] count = new int[256];
        int[] rank = new int[length];

        for (int i = 0; i < length; i++)
        {
            rank[i] = count[bwt[i]];
            count[bwt[i]]++;
        }

        int[] start = new int[256];
        int sum = 0;
        for (int i = 0; i < 256; i++)
        {
            int temp = count[i];
            count[i] = sum;
            sum += temp;
            start[i] = count[i];
        }

        int[] next = new int[length];
        for (int i = 0; i < length; i++)
        {
            next[start[bwt[i]]] = i;
            start[bwt[i]]++;
        }

        char[] original = new char[length];
        int j = this.originalIndexStart;
        for (int i = length - 1; i >= 0; i--)
        {
            original[i] = bwt[j];
            j = next[j];
        }

        Console.WriteLine($"To deconvert = {new string(original)}");
        return new string(original);
    }
}

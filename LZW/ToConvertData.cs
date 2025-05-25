namespace LZW;

using System.Text;

/// <summary>
/// Transforms a string using the Burrows Wheeler algorithm.
/// </summary>
public class BWT
{
    private int originalIndexStart;

    /// <summary>
    /// Transforms a string using the Burrows Wheeler algorithm.
    /// </summary>
    /// <param name="str"> Initial value of the string. </param>
    /// <returns> Returns the converted string. </returns>
    public string ToConvert(string str)
    {
        return this.ToConvertString(str);
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

    private string ToConvertString(string originalStr)
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
        }

        return resultStr.ToString();
    }

    private int FindIndexOfMaxString(StringBuilder str, List<int> strList)
    {
        int maxIndex = 0;
        for (int i = 1; i < strList.Count; i++)
        {
            if (this.IsLarger(str, strList[i], strList[maxIndex]))
            {
                maxIndex = i;
            }
        }

        return maxIndex;
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

    private string ToDeconvertString(string str)
    {
        char[] strArray = str.ToCharArray();
        char[] strSortedArray = str.ToCharArray();
        Array.Sort(strSortedArray);

        int[] arrayOfIndeexesForStr = new int[strArray.Length];
        Array.Fill(arrayOfIndeexesForStr, -1);

        for (int i = 0; i < str.Length; ++i)
        {
            for (int j = 0; j < str.Length; ++j)
            {
                if (strArray[j] == strSortedArray[i] && arrayOfIndeexesForStr[j] == -1)
                {
                    arrayOfIndeexesForStr[j] = i;
                    break;
                }
            }
        }

        StringBuilder resultStr = new ();

        int index = this.originalIndexStart;
        for (int i = 0; i < str.Length; ++i)
        {
            resultStr.Append(strArray[index]);

            for (int j = 0; j < arrayOfIndeexesForStr.Length; ++j)
            {
                if (arrayOfIndeexesForStr[j] == index)
                {
                    index = j;
                    break;
                }
            }
        }

        return resultStr.ToString();
    }
}

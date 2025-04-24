namespace LZW;

public class BarrowW
{
    public string str;

    public BarrowW(string str1)
    {
        str = str1;
    }

    public string Result()
    {
        string resultStr = "";
        List<int> resIntStr = NewString(str);
        foreach (var i in resIntStr)
        {
            resultStr += str[i];
        }
        return resultStr;
    }

    private List<int> NewString(string str)
    {
        List<int> resultStr = new();
        resultStr.Add(CompareString(0));

        for (var i = 0; i < str.Length; ++i)
        {
            resultStr.Add(CompareString(resultStr.Last()));
        }

        return resultStr;
    }

    private int CompareString(int index)
    {
        int i = 0;
        int indexNext = (index + 1) % str.Length;
        int minIndex = 0;
        int checkMaxIndex = 0;

        for (var j = 0; j < str.Length; ++j)
        {
            if (str[(indexNext + i) % str.Length] > str[(index + i) % str.Length])
            {
                if (i > checkMaxIndex)
                {
                    checkMaxIndex = i;
                    minIndex = indexNext;
                }
                indexNext++;
                i = 0;
                continue;
            }
            i++;
        }

        return minIndex;
    }

    public void firstPreviosString()
    {

    }
}

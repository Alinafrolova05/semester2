namespace LZW;

public class BarrowW
{
    public string Result(string str)
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
        resultStr.Add(0);

        for (var i = 0; i < str.Length; ++i)
        {
            resultStr.Add(CompareString(str, resultStr));
        }

        Console.WriteLine($"str = {str}");
        foreach(var c in resultStr)
        {
            Console.WriteLine($"resStr = {c}");
        }

        return resultStr;
    }

    private int CompareString(string str, List<int> resultStr)
    {
        int index = resultStr.Last();
        int minIndex = index;
        int checkMaxIndexLenght = 0;

        int currentIndex = (index) % str.Length;
        int indexNext = (index + 1) % str.Length;

        for (int i = 0; i < str.Length; i++)
        {
            int check = CompareStringAndReturnLenght(str, index, indexNext);
            if (check > checkMaxIndexLenght && !resultStr.Contains(indexNext))
            {
                minIndex = indexNext;
                checkMaxIndexLenght = i;
            }
            indexNext = (indexNext + 1) % str.Length;
        }
        Console.WriteLine(minIndex);

        return minIndex;
    }

    public int CompareStringAndReturnLenght(string str, int index, int indexNext)
    {
        int checkMaxIndexLenght = 0;
        for (var i = 0; i < str.Length; ++i)
        {
            if (str[index % str.Length] > str[indexNext % str.Length])
            {
                break;
            }
            checkMaxIndexLenght++;
        }

        return checkMaxIndexLenght;
    }

    public List<char> firstPreviosString(string sortedStr, string strDecompress)
    {
        List<int> visitedIndexes = new();
        List<char> resultStr = new();

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

namespace UserFile
{
    public class t
    {
        public static string Solution(string str)
        {
            string sortedStr = f.f.SortString(str);
            string resultStr = "";
            int index = 0;
            List<char> charList = new List<char>();

            for (var i = 0; resultStr.Length < str.Length; i++)
            {
                string previousLine = str;
                str = f.f.ShiftRight(str);

                if (str[0] == sortedStr[index])
                {
                    int j = 0;
                    while (String.Compare(previousLine, str) > 0)
                    {
                        if (i == 0)
                        {
                            break;
                        }
                        if (previousLine[previousLine.Length - 1] == charList[charList.Count - 1 - j])
                        {
                            j++;
                        }
                        previousLine = f.f.ShiftLeft(previousLine);
                    }

                    int insertPosition = resultStr.Length - j;
                    charList.Add(str[str.Length - 1]);
                    resultStr = f.f.InsertCharacter(resultStr, str[str.Length - 1], insertPosition);
                    index++;
                }
            }
            return resultStr;
        }
    }
}

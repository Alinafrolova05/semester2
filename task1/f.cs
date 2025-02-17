namespace f
{
    public class f
    {
        public static string InsertCharacter(string str, char element, int position)
        {
            if (position < 0 || position > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Error!");
            }

            return str.Insert(position, element.ToString());
        }

        public static string SortString(string input)
        {
            if (input.Length == 0) return input;
            char[] charArray = input.ToCharArray();
            Array.Sort(charArray);
            return new string(charArray);
        }

        public static string ShiftLeft(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length == 1) return str;
            char firstChar = str[0];
            return str.Substring(1) + firstChar;
        }

        public static string ShiftRight(string input)
        {
            if (input.Length == 0) return input;
            char lastChar = input[input.Length - 1];
            return lastChar + input.Substring(0, input.Length - 1);
        }
    }
}

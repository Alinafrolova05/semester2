using System;
using System.Collections.Generic;
using System.Linq;
namespace LZW;

class Coding
{
    Dictionary<string, int> dictionary;
    public Coding()
    {
        dictionary = new();
    } 

    private void fillingTheDictionary(string Str)
    {
        int index = 0;
        string CheckString = "";
        for (var i = 0; i < Str.Length; ++i)
        {
            CheckString += Str[i];
            if (!dictionary.ContainsKey(CheckString))
            {
                dictionary.Add(CheckString, index);
                index++;
                CheckString = "";
            }
        }
    }

    public List<int> CompressData (string Str)
    {
        fillingTheDictionary(Str);
        List<int> ResultString = new();

        string CheckString = "";
        for (var i = 0; i < Str.Length; ++i)
        {
            string SeconCheckString = CheckString += Str[i];
            if (!dictionary.ContainsKey(SeconCheckString))
            {
                ResultString.Add(dictionary[CheckString]);
                CheckString = "";
            }
            CheckString += Str[i];
        }
        return ResultString;
    }

    public string DecompressData(List<int> ResultString)
    {
        string OriginalString = "";
        for (var i = 0; i < ResultString.Count; ++i)
        {
            OriginalString += dictionary.FirstOrDefault(x => x.Value == ResultString[i]).Key;
        }
        return OriginalString;
    }
}

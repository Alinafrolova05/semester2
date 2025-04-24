using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LZW;

public class Coding
{
    Tree treeBor;
    public Dictionary<string, int> dictionary;
    Dictionary<int, string> reverseDictionary;
    int index;

    public Coding()
    {
        index = 0;
        dictionary = new();
        reverseDictionary = new();
    }

    public void CompressData(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            Console.WriteLine(line);
            string checkString = "";
            List<int> compressedData = new();

            foreach (var c in line)
            {
                string checkPlusChar = checkString + c;

                if (dictionary.ContainsKey(checkPlusChar))
                {
                    checkString = checkPlusChar;
                }
                else
                {
                    if (!string.IsNullOrEmpty(checkString))
                    {
                        compressedData.Add(dictionary[checkString]);
                    }
                    dictionary.Add(checkPlusChar, index);
                    reverseDictionary.Add(index, checkPlusChar);
                    index++;

                    checkString = "";
                }
            }

            if (!string.IsNullOrEmpty(checkString) && dictionary.ContainsKey(checkString))
            {
                compressedData.Add(dictionary[checkString]);
            }

            Console.WriteLine(string.Join(" ", compressedData));
            Console.WriteLine($"{line.Length/ compressedData.Count}");

            File.AppendAllText("NewFile.zipped", string.Join(" ", compressedData) + "\n");
        }
    }

    public void CompressDataBor(List<Node> listOfNodes)
    {
        if (treeBor.root.ListOfTrees == null)
        {
            return;
        }


        foreach(var child in listOfNodes)
        {
            CompressDataBor(child.ListOfTrees);
        }
    }

    public void ReadFromFileInBor (string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] words = line.Split(new char[] { ' ', '\t', ',', '.', '!', '?' }, 
                StringSplitOptions.RemoveEmptyEntries);
            foreach(var word in words)
            {
                treeBor.Add(word);
            }
        }
    }

    public void DecompressData(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var indices = line.Split(' ').Select(int.Parse).ToList();
            string previous = reverseDictionary[indices[0]];

            Console.Write(previous);

            foreach (var index in indices.Skip(1))
            {
                string current = "";
                if (reverseDictionary.ContainsKey(index))
                {
                    current = reverseDictionary[index];
                }
                else if (index == reverseDictionary.Count)
                {
                    current = previous + previous[0];
                }
                else
                {
                    continue;
                }

                reverseDictionary.Add(index, previous + current[0]);
                previous = current;
            }
        }
    }
}

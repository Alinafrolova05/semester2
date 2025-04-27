using System.Collections;
using System;
using System.Collections.Generic;

namespace LZW;

public class Node
{
    public char Value;
    public int IsEndOfWord;
    public List<Node> ListOfTrees;
    
    public Node(char value)
    {
        Value = value;
        ListOfTrees = new();
    }
}

public class Tree
{
    BarrowW newString;
    public Node root;
    public int count;
    public Dictionary<string, int> dictionary;
    Dictionary<int, string> reverseDictionary;
    int index;

    public Tree(string filePath)
    {
        newString = new();
        root = new(' ');
        dictionary = new();
        reverseDictionary = new();
        ReadFileAndCreateATree(filePath);
    }

    public void ReadFileAndCreateATree(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] words = line.Split(new char[] { ' ', '\t', ',', '.', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                AddWordInTree(root.ListOfTrees, ConvertWordToLZW(newString.Result(word)), count);
            }
        }
    }

    private void AddWordInTree(List<Node> ListOfNodes, string str, int count)
    {
        for (var i = 0; i < str.Length; ++i)
        {
            Node node = searchInList(ListOfNodes, str[i]);
            if (node == null)
            {
                Node newNode = new(str[i]);
                if (i == str.Length - 1)
                {
                    newNode.IsEndOfWord = count;
                    count++;
                }
                ListOfNodes.Add(newNode);
                ListOfNodes = newNode.ListOfTrees;
            }
            else
            {
                ListOfNodes = node.ListOfTrees;
            }
        }
    }

    private Node searchInList(List<Node> ListOfNodes, char value)
    {
        foreach (var node in ListOfNodes)
        {
            if (node.Value == value)
            {
                return node;
            }
        }
        return null;
    }

    public string ConvertWordToLZW(string word)
    {
        string checkString = "";
        string compressedData = "";

        foreach (var c in word)
        {
            string checkPlusChar = checkString + c;

            if (dictionary.ContainsKey(checkPlusChar))
            {
                checkString = checkPlusChar;
            }
            else
            {
                dictionary.Add(checkPlusChar, index);
                reverseDictionary.Add(index, checkPlusChar);
                index++;

                Console.WriteLine($"In dictionary - {checkPlusChar}");
                compressedData += dictionary[checkPlusChar].ToString() + " ";

                checkString = "";
            }
        }

        if (!string.IsNullOrEmpty(checkString))
        {
            compressedData += dictionary[checkString].ToString();
        }

        Console.WriteLine($"{word} - {compressedData}");
        return compressedData;
    }

    public void DecompressedDataFullByGoingInTree(Node currentNode, List<int>[] arrayOfStr, List<int> strList)
    {
        if (currentNode == null)
        {
            return;
        }

        if (currentNode.IsEndOfWord > 0)
        {
            arrayOfStr[currentNode.IsEndOfWord] = new(strList);
            strList.Clear();
        }

        foreach (var node in currentNode.ListOfTrees)
        {
            strList.Add(currentNode.Value - '0');
            DecompressedDataFullByGoingInTree(node, arrayOfStr, strList);
            strList.RemoveAt(strList.Count - 1);
        }
    }

    public void DecompressLZWWord(List<int>[] arrayOfStr, List<string> words)
    {
       for (var i = 0; i < arrayOfStr.Length; ++i)
       {
            string str = "";
            foreach (var c in arrayOfStr[i])
            {
                if (reverseDictionary.ContainsKey(c))
                {
                    str += reverseDictionary[c];
                }
            }
            words[i] = str;
       }
    }
}

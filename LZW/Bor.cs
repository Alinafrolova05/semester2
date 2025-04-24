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

    public Tree()
    {
        root = new(' ');
        dictionary = new();
        reverseDictionary = new();
    }

    public void Add(string str)
    {
        AddWord(root.ListOfTrees, str, count);
    }

    private void AddWord(List<Node> ListOfNodes, string str, int count)
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

    public void AddWordLZWBor(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] words = line.Split(new char[] { ' ', '\t', ',', '.', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach(var word in words)
            {
                AddWord(root.ListOfTrees, LWWWord(word), count);
            }
        }
    }

    public string LWWWord(string word)
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
                if (!string.IsNullOrEmpty(checkString))
                {
                    compressedData += dictionary[checkString].ToString();
                }
                dictionary.Add(checkPlusChar, index);
                reverseDictionary.Add(index, checkPlusChar);
                index++;

                checkString = c.ToString();
            }
        }

        if (!string.IsNullOrEmpty(checkString) && dictionary.ContainsKey(checkString))
        {
            compressedData += dictionary[checkString].ToString();
        }
        return compressedData;
    }

    private Node searchInList(List<Node> ListOfNodes, char value)
    {
        foreach(var node in ListOfNodes)
        {
            if (node.Value == value)
            {
                return node;
            }
        }
        return null;
    }

    public void DecompressedDataFullByGoingInTree(Node root1, List<int>[] arrayOfStr, List<int> strList)
    {
        if (root1 == null)
        {
            return;
        }
        if (root1.IsEndOfWord > 0)
        {
            arrayOfStr[root1.IsEndOfWord] = strList;
            strList.Clear();
        }
        foreach (var node in root1.ListOfTrees)
        {
            strList.Add(root.Value - '0');
            DecompressedDataFullByGoingInTree(node, arrayOfStr, strList);
        }
    }

    public void DecompressLZWWord(List<int>[] arrayOfStr)
    {
       foreach(var word in arrayOfStr)
       {
            foreach(var c in word)
            {

            }
       }
    }
}

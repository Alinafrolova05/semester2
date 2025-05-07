namespace LZW;

using System.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

/// <summary>
/// This is a tree node.
/// </summary>
public class Node
{
    private char value;
    private int isEndOfWord;
    private List<Node> listOfTrees;

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class.
    /// </summary>
    /// <param name="value"> The value Of node. </param>
    public Node(char value)
    {
        this.value = value;
        this.listOfTrees = new ();
    }

    /// <summary>
    /// 
    /// </summary>
    public char Value
    {
        get { return this.value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public int IsEndOfWord
    {
        get { return this.isEndOfWord; }
        set { this.isEndOfWord = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public List<Node> ListOfTrees
    {
        get { return this.listOfTrees; }
    }
}

/// <summary>
/// Implements Bor.
/// </summary>
public class Tree
{
    private readonly BarrowW newString;
    private readonly Node root;
    private readonly int count;
    private readonly Dictionary<string, int> dictionary;
    private readonly Dictionary<int, string> reverseDictionary;
    private int index;

    /// <summary>
    /// Initializes a new instance of the <see cref="Tree"/> class.
    /// </summary>
    /// <param name="filePath"> The path of file. </param>
    /// <param name="value"> The value of node. </param>

    public Tree(string filePath)
    {
        this.newString = new ();
        this.root = new (' ');
        this.dictionary = new ();
        this.reverseDictionary = new ();
        this.ReadFileAndCreateATree(filePath);
    }

    private void ReadFileAndCreateATree(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] words = line.Split([' ', '\t', ',', '.', '!', '?'], StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                this.AddWordInTree(this.root.ListOfTrees, this.ConvertWordToLZW(this.newString.Result(word)), this.count);
            }
        }
    }

    private void AddWordInTree(List<Node> listOfNodes, string str, int count)
    {
        for (var i = 0; i < str.Length; ++i)
        {
            Node node = this.SearchInList(listOfNodes, str[i]);
            if (node == null)
            {
                Node newNode = new(str[i]);
                if (i == str.Length - 1)
                {
                    newNode.IsEndOfWord = count;
                    count++;
                }

                listOfNodes.Add(newNode);
                listOfNodes = newNode.ListOfTrees;
            }
            else
            {
                listOfNodes = node.ListOfTrees;
            }
        }
    }

    private Node? SearchInList(List<Node> listOfNodes, char value)
    {
        foreach (var node in listOfNodes)
        {
            if (node.Value == value)
            {
                return node;
            }
        }

        return null;
    }

    private string ConvertWordToLZW(string word)
    {
        string checkString = string.Empty;
        string compressedData = string.Empty;

        foreach (var c in word)
        {
            string checkPlusChar = checkString + c;

            if (this.dictionary.ContainsKey(checkPlusChar))
            {
                checkString = checkPlusChar;
            }
            else
            {
                this.dictionary.Add(checkPlusChar, this.index);
                this.reverseDictionary.Add(this.index, checkPlusChar);
                this.index++;

                compressedData += this.dictionary[checkPlusChar].ToString() + " ";
                checkString = string.Empty;
            }
        }

        if (!string.IsNullOrEmpty(checkString))
        {
            compressedData += this.dictionary[checkString].ToString();
        }
        Console.WriteLine($" word = {word}, compressedData = {compressedData} ");

        return compressedData;
    }

    private void DecompressedDataFullByGoingInTree(Node currentNode, List<int>[] arrayOfStr, List<int> strList)
    {
        if (currentNode == null)
        {
            return;
        }

        if (currentNode.IsEndOfWord > 0)
        {
            arrayOfStr[currentNode.IsEndOfWord] = new (strList);
            strList.Clear();
        }

        foreach (var node in currentNode.ListOfTrees)
        {
            strList.Add(currentNode.Value - '0');
            this.DecompressedDataFullByGoingInTree(node, arrayOfStr, strList);
            strList.RemoveAt(strList.Count - 1);
        }
    }

    private void DecompressLZWWord(List<int>[] arrayOfStr, List<string> words)
    {
       for (var i = 0; i < arrayOfStr.Length; ++i)
       {
            string str = string.Empty;
            foreach (var c in arrayOfStr[i])
            {
                if (this.reverseDictionary.ContainsKey(c))
                {
                    str += this.reverseDictionary[c];
                }
            }

            words[i] = str;
       }
    }
}

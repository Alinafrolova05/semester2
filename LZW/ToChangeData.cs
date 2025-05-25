namespace LZW;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Implements Bor.
/// </summary>
public class Tree
{
    private readonly BWT newString;
    private readonly Node root;
    private readonly int count;
    private readonly Dictionary<string, int> dictionary;
    private readonly Dictionary<int, string> reverseDictionary;
    private int index;
    private string extensionOffile;

    /// <summary>
    /// Initializes a new instance of the <see cref="Tree"/> class.
    /// </summary>
    /// <param name="filePath"> The path of file. </param>
    /// <param name="value"> The value of node. </param>
    public Tree()
    {
        this.newString = new ();
        this.root = new (' ');
        this.dictionary = new ();
        this.reverseDictionary = new ();
    }

    /// <summary>
    /// Compress file.
    /// </summary>
    /// <param name="filePath"> FilePath. </param>
    public void Compress(string filePath)
    {
        this.extensionOffile = Path.GetExtension(filePath);

        if (!File.Exists(filePath))
        {
            return;
        }

        this.ReadFileAndCompress(filePath);
    }

    /// <summary>
    /// Decompress file.
    /// </summary>
    /// <param name="filePath"> FilePath. </param>
    public void Decompress(string filePath)
    {
        if (!File.Exists(filePath) || Path.GetExtension(filePath) != ".zipped")
        {
            return;
        }

        this.DecompressAndWriteInFile(filePath);
    }

    private void ReadFileAndCompress(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] words = line.Split([' ', '\t', ',', '.', '!', '?', '\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                StringBuilder str = this.ConvertWordToLZW(this.newString.ToConvert(word));
                this.AddWordInTree(this.root.ListOfTrees, str, this.count);
                File.WriteAllText(filePath, str.ToString());
            }
        }

        string newFilePath = Path.ChangeExtension(filePath, ".zipped");
        File.Move(filePath, newFilePath);
    }

    private void AddWordInTree(List<Node> listOfNodes, StringBuilder str, int count)
    {
        for (var i = 0; i < str.Length; ++i)
        {
            Node? node = this.SearchInList(listOfNodes, str[i]);
            if (node == null)
            {
                Node newNode = new (str[i]);
                if (i == str.Length - 1)
                {
                    count++;
                    newNode.IsEndOfWord = count;
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

    private StringBuilder ConvertWordToLZW(string word)
    {
        string checkString = string.Empty;
        var compressedData = new StringBuilder();

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

                compressedData.Append(this.dictionary[checkPlusChar].ToString() + " ");
                checkString = string.Empty;
            }
        }

        if (!string.IsNullOrEmpty(checkString))
        {
            compressedData.Append(this.dictionary[checkString].ToString());
        }

        return compressedData;
    }

    private void DecompressAndWriteInFile(string filePath)
    {
        using (StreamWriter writer = new (filePath, append: false))
        {
            foreach (string word in this.GoingInTree(this.root))
            {
                if (word == null)
                {
                    continue;
                }

                writer.WriteLine(word);
            }
        }

        string newFilePath = Path.ChangeExtension(filePath, this.extensionOffile);
        File.Move(filePath, newFilePath);
    }

    private string[]? GoingInTree(Node currentNode)
    {
        if (currentNode == null)
        {
            return null;
        }

        string[] listOfStrings = new string[256];
        StringBuilder word = new ();
        Stack<Node> stack = new ();
        stack.Push(currentNode);
        int count = 0;

        while (stack.Count > 0)
        {
            Node node = stack.Pop();
            count++;

            if (node.IsEndOfWord > 0)
            {
                if (node.IsEndOfWord >= listOfStrings.Length)
                {
                    Array.Resize(ref listOfStrings, listOfStrings.Length * 2);
                }

                listOfStrings[node.IsEndOfWord] = this.newString.ToDeconvert(word.ToString());
                Console.WriteLine(listOfStrings[node.IsEndOfWord]);
            }

            foreach (var childNode in node.ListOfTrees)
            {
                if (childNode != null)
                {
                    if (childNode.Value - '0' >= 0)
                    {
                        word.Append(this.reverseDictionary[childNode.Value - '0']);
                    }

                    stack.Push(childNode);
                }
                else
                {
                    word.Clear();
                }
            }
        }

        return listOfStrings;
    }
}

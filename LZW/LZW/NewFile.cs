// <copyright file="NewFile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW;

#pragma warning restore CS0649

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Implements Bor.
/// </summary>
public class NewFile
{
    private readonly ConvertData convertedString = new();
    private readonly Tree root = new(' ');
    private readonly Dictionary<string, int> dictionaryOfNewlyDiscoveredWords = [];
    private readonly Dictionary<int, string> reverseDictionary = [];
    private int countOfWords;
    private int countOfNewlyDiscoveredWords;
    private string? extenionOfFileToCompress;

    /// <summary>
    /// Compress or decompress file.
    /// </summary>
    /// <param name="filePath"> FilePath. </param>
    /// <param name="key"> the key says to compress or decompress the file. </param>
    public void ChangeFile(string filePath, string key)
    {
        if (key == "-c")
        {
            this.Compress(filePath);
        }

        if (key == "-u")
        {
            this.Decompress(filePath);
        }
    }

    private static void AddWordInTree(List<Tree> listOfNodes, StringBuilder str, ref int countOfWords)
    {
        for (var i = 0; i < str.Length; ++i)
        {
            Tree? node = SearchInList(listOfNodes, str[i]);
            if (node == null)
            {
                Tree newNode = new(str[i]);
                if (i == str.Length - 1)
                {
                    countOfWords++;
                    newNode.IsEndOfWord = countOfWords;
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

    private static Tree? SearchInList(List<Tree> listOfNodes, char value)
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

    private void Compress(string filePath)
    {
        this.extenionOfFileToCompress = Path.GetExtension(filePath);

        if (!File.Exists(filePath))
        {
            return;
        }

        this.ReadFileAndCompress(filePath);
    }

    private void Decompress(string filePath)
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
            StringBuilder str = this.ConvertWordToLZW(this.convertedString.Convert(line));
            AddWordInTree(this.root.ListOfTrees, str, ref this.countOfWords);
            File.WriteAllText(filePath, str.ToString());
        }

        string newFilePath = Path.ChangeExtension(filePath, ".zipped");
        File.Move(filePath, newFilePath);
    }

    private StringBuilder ConvertWordToLZW(string word)
    {
        string checkString = string.Empty;
        var compressedData = new StringBuilder();

        foreach (var c in word)
        {
            string checkPlusChar = checkString + c;

            if (!this.dictionaryOfNewlyDiscoveredWords.TryAdd(checkPlusChar, this.countOfNewlyDiscoveredWords))
            {
                checkString = checkPlusChar;
            }
            else
            {
                this.reverseDictionary.Add(this.countOfNewlyDiscoveredWords, checkPlusChar);
                this.countOfNewlyDiscoveredWords++;

                compressedData.Append(this.dictionaryOfNewlyDiscoveredWords[checkPlusChar].ToString() + " ");
                checkString = string.Empty;
            }
        }

        if (!string.IsNullOrEmpty(checkString))
        {
            compressedData.Append(this.dictionaryOfNewlyDiscoveredWords[checkString]);
        }

        return compressedData;
    }

    private void DecompressAndWriteInFile(string filePath)
    {
        var words = this.GoInTree(this.root);

        if (words == null || words.Length == 0)
        {
            return;
        }

        using (StreamWriter writer = new(filePath, append: false))
        {
            foreach (string word in words)
            {
                if (word == null)
                {
                    continue;
                }

                writer.WriteLine(word);
            }
        }

        string newFilePath = Path.ChangeExtension(filePath, this.extenionOfFileToCompress);
        File.Move(filePath, newFilePath);
    }

    private string[]? GoInTree(Tree currentNode)
    {
        if (currentNode == null)
        {
            return null;
        }

        string[] listOfStrings = new string[256];
        StringBuilder word = new();
        Stack<Tree> stack = new();
        stack.Push(currentNode);
        int count = 0;

        while (stack.Count > 0)
        {
            Tree node = stack.Pop();
            count++;

            if (node.IsEndOfWord > 0)
            {
                if (node.IsEndOfWord >= listOfStrings.Length)
                {
                    Array.Resize(ref listOfStrings, listOfStrings.Length * 2);
                }

                listOfStrings[node.IsEndOfWord] = this.convertedString.Deconvert(word.ToString());
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

// <copyright file="BorLZW.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
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
public class BorLZW
{
    private readonly BwtResult convertedString = new();
    private readonly Tree root = new(' ');
    private readonly Dictionary<string, int> dictionaryOfNewlyDiscoveredWords = [];
    private readonly Dictionary<int, string> reverseDictionary = [];
    private int countOfWords;
    private int countOfNewlyDiscoveredWords;
    private string? extensionOfFileToCompress;

    /// <summary>
    /// Compresses the file specified by the filePath.
    /// </summary>
    /// <param name="filePath">The path of the file to be compressed.</param>
    public void Compress(string filePath)
    {
        this.extensionOfFileToCompress = Path.GetExtension(filePath);

        if (!File.Exists(filePath))
        {
            return;
        }

        this.ReadFileAndCompress(filePath);
    }

    /// <summary>
    /// Decompresses the file specified by the filePath.
    /// </summary>
    /// <param name="filePath">The path of the file to be decompressed.</param>
    public void Decompress(string filePath)
    {
        if (!File.Exists(filePath) || Path.GetExtension(filePath) != ".zipped")
        {
            return;
        }

        this.DecompressAndWriteInFile(filePath);
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

    private void ReadFileAndCompress(string filePath)
    {
        if (Path.GetExtension(filePath).ToLower() == ".txt")
        {
            var lines = File.ReadAllLines(filePath);
            StringBuilder compressedData = new();

            foreach (var line in lines)
            {
                StringBuilder str = this.ConvertWordToLZW(this.convertedString.Bwt(line));
                AddWordInTree(this.root.ListOfTrees, str, ref this.countOfWords);
                compressedData.AppendLine(str.ToString());
            }

            File.WriteAllText(filePath, compressedData.ToString());
        }
        else
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            string originalString = System.Text.Encoding.UTF8.GetString(fileBytes);
            StringBuilder compressedData = this.ConvertWordToLZW(this.convertedString.Bwt(originalString));

            byte[] compressedBytes = System.Text.Encoding.UTF8.GetBytes(compressedData.ToString());
            File.WriteAllBytes(filePath, compressedBytes);
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

        string newFilePath = Path.ChangeExtension(filePath, this.extensionOfFileToCompress);
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

                listOfStrings[node.IsEndOfWord] = this.convertedString.ToDeconvertFromBwt(word.ToString());
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

// <copyright file="Bor.cs" company="Alina">
// Copyright (c) Alina. All rights reserved.
// </copyright>

namespace Bor;

using System;

/// <summary>
/// The Bor class implements a trie (prefix tree) data structure.
/// </summary>
internal class Bor
{
    private Node root = new();

    private int size = 0;

    /// <summary>
    /// Adds a string to the trie.
    /// </summary>
    /// <param name="word">The string to add. </param>
    /// <returns>True if the string was added for the first time, otherwise false. </returns>
    public bool Add(string word)
    {
        var current = this.root;

        foreach (var ch in word)
        {
            if (!current.Children.TryGetValue(ch, out var next))
            {
                next = new Node();
                current.Children[ch] = next;
            }

            current = next;
        }

        if (current.IsEndOfWord)
        {
            return false;
        }

        current.IsEndOfWord = true;
        this.size++;
        return true;
    }

    public bool RemoveWord(string word)
    {
        if (!Search(word))
        {
            return false;
        }

        return Remove(this.root, word, 0);
    }

    /// <summary>
    /// Counts how many strings in the trie start with the given prefix.
    /// </summary>
    /// <param name="prefix"></param>
    /// <returns></returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        var current = this.root;

        foreach (var ch in prefix)
        {
            if (!current.Children.TryGetValue(ch, out var nextNode))
            {
                return 0;
            }

            current = nextNode;
        }

        return CountWords(current);
    }

    /// <summary>
    /// Gets the total number of strings stored in the trie.
    /// </summary>
    public int Size => this.size;

    private bool Remove(Node current, string word, int index)
    {
        if (index == word.Length)
        {
            if (!current.IsEndOfWord)
            {
                return false;
            }

            current.IsEndOfWord = false;
            return current.Children.Count == 0;
        }

        char ch = word[index];

        if (!current.Children.TryGetValue(ch, out var nextNode))
        {
            return false;
        }

        bool shouldDeleteCurrentNode = Remove(nextNode, word, index + 1);

        if (shouldDeleteCurrentNode)
        {
            current.Children.Remove(ch);
            return current.Children.Count == 0 && !current.IsEndOfWord;
        }

        return false;
    }

    private bool Search(string word)
    {
        var current = this.root;
        foreach (var ch in word)
        {
            if (!current.Children.TryGetValue(ch, out var next))
            {
                return false;
            }

            current = next;
        }

        return current.IsEndOfWord;
    }

    private int CountWords(Node node)
    {
        int count = node.IsEndOfWord ? 1 : 0;

        foreach (var child in node.Children.Values)
        {
            count += CountWords(child);
        }

        return count;
    }

    private record Node
    {
        public Dictionary<char, Node> Children { get; init; } = new();

        public bool IsEndOfWord { get; set; }
    }
}

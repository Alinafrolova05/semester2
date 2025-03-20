using System;

namespace Bor;
class Bor
{
    public Node root;

    public Bor()
    {
        root = new Node();
    }

    public bool Add(string str)
    {
        Node currentNode = root;

        foreach (char c in str)
        {
            currentNode.AddChild(c);
            currentNode = currentNode.MoveToNextNode(c);
        }

        if (!currentNode.IsEndOfWord)
        {
            currentNode.IsEndOfWord = true;
            return true;
        }

        return false;
    }

    public bool Contains(string element)
    {
        Node currentNode = root;

        foreach (char c in element)
        {
            currentNode = currentNode.MoveToNextNode(c);
            if (currentNode == null)
            {
                return false;
            }
        }

        return currentNode.IsEndOfWord;
    }

    public bool Remove(string element)
    {
        return RemoveHelper(root, element, 0);
    }

    private bool RemoveHelper(Node currentNode, string element, int index)
    {
        if (index == element.Length)
        {
            if (!currentNode.IsEndOfWord)
            {
                return false;
            }

            currentNode.IsEndOfWord = false;
            return currentNode.LinkedNodes.Count == 0;
        }

        char substring = element[index];
        Node nextNode = currentNode.MoveToNextNode(substring);
        if (nextNode == null)
        {
            return false;
        }

        bool shouldDeleteCurrentNode = RemoveHelper(nextNode, element, index + 1);

        if (shouldDeleteCurrentNode)
        {
            currentNode.LinkedNodes.Remove(substring);
            return currentNode.LinkedNodes.Count == 0 && !currentNode.IsEndOfWord;
        }

        return false;
    }

    public int HowManyStartsWithPrefix(string prefix)
    {
        Node currentNode = root;

        foreach (char c in prefix)
        {
            currentNode = currentNode.MoveToNextNode(c);
            if (currentNode == null)
            {
                return 0;
            }
        }

        return CountWords(currentNode);
    }

    private int CountWords(Node node)
    {
        int count = node.IsEndOfWord ? 1 : 0;

        foreach (var child in node.LinkedNodes.Values)
        {
            count += CountWords(child);
        }

        return count;
    }

    public int Size()
    {
        return CountWords(root);
    }

    private int Count(Node node)
    {
        int numberOfSimbols = 0;

        foreach (var child in node.LinkedNodes)
        {
            var childNumberOfSimbols = Count(child.Value);
            numberOfSimbols += childNumberOfSimbols + 1;
        }

        return (numberOfSimbols);
    }

    public int CountSymbols()
    {
        return Count(root);
    }

    public class Node
    {
        public Dictionary<char, Node> LinkedNodes { get; set; }
        public bool IsEndOfWord { get; set; }

        public Node()
        {
            LinkedNodes = new Dictionary<char, Node>();
            IsEndOfWord = false;
        }

        public void AddChild(char value)
        {
            if (!LinkedNodes.ContainsKey(value))
            {
                LinkedNodes[value] = new Node();
            }
        }

        public Node MoveToNextNode(char value)
        {
            LinkedNodes.TryGetValue(value, out var nextNode);
            return nextNode;
        }
    }
}
